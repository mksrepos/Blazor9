using BlazorWebApp2.Components;
using BlazorWebApp2.Components.Demo04Misc.Models;
using BlazorWebApp2.Components.Pages;


var builder = WebApplication.CreateBuilder(args);


//----- Add services to the container.

// The following lines have been commented out for Eg01 of Demo09Errors
//builder.Services
//    .AddRazorComponents()                         // adds support for Razor Components
//    .AddInteractiveServerComponents()             // adds services to support Interactive Server-side Rendering (interactive SSR) components
//    .AddInteractiveWebAssemblyComponents();       // adds services to support rendering Interactive WebAssembly components

builder.Services
    .AddRazorComponents()                           // adds support for Razor Components
    .AddInteractiveServerComponents()               // adds services to support Interactive Server-side Rendering (interactive SSR) components
        .AddHubOptions( configOptions =>
        {
            // Enable detailed errors for user state held in server memory (called Blazor Circuits)
            // Check out: https://learn.microsoft.com/en-us/aspnet/core/blazor/state-management?view=aspnetcore-9.0&pivots=server#maintain-user-state
            configOptions.EnableDetailedErrors = builder.Environment.IsDevelopment();
        } )
        .AddCircuitOptions( configOptions =>
        {
            // Enable detailed errors for user state held in server memory (called Blazor Circuits)
            // Check out: https://learn.microsoft.com/en-us/aspnet/core/blazor/state-management?view=aspnetcore-9.0&pivots=server#maintain-user-state
            configOptions.DetailedErrors = builder.Environment.IsDevelopment();
        } )
    .AddInteractiveWebAssemblyComponents();          // adds services to support rendering Interactive WebAssembly components


// Register the Configuration typed options model into the application services DI container 
builder.Services
    .AddOptions<MyAppOptionsModel>()
    .BindConfiguration( "MyAppOptions" )                // section name in appsettings.json file
    .ValidateDataAnnotations()                          // to enforce validation rules
    .ValidateOnStart()                                  // add if needed.
    .Validate( options =>
    {
        if ( options.TrainerName == "Manoj Kumar Sharma" )
        {
            return true;
        }

        // throws the Microsoft.Extensions.Options.OptionsValidationException:
        // with the default message: 'A validation error has occurred.'
        return false;
    } );

// Register the Bogus Generator Services
builder.Services.AddTransient<BlazorWebApp2.Services.BogusGenerators.BogusProductService>();
builder.Services.AddTransient<BlazorWebApp2.Services.BogusGenerators.BogusPersonService>();

// Register the Services needed to enable ASP.NET Controllers and Web API Controllers
builder.Services.AddControllers();

// Register the HttpClient in the DI Services container
// for blazor components to be able to call API endpoints.
// (for example in Demo04Misc/Eg03ApiCall.razor)
builder.Services.AddHttpClient();

// Register the HttpContextAccessor to the DI Services container (if needed)
// for blazor components to be able to access the HTTP Context object when needed 
// (for example in Demo09Errors/Eg04ErrorBoundaryComponent.razor)
// IMPORTANT NOTE: Should be used only in Blazor projects which support Interactive SSR components.
builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// ----- Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Add the Anti-ForgeryToken Middleware.
// NOTE: Either add the AntiforgeryToken explicitly in the EditForm component,
//       OR configure to add the middleware at the application level in Program.cs
//       Adding both, generates two anti-forgery tokens into the form, which causes conflict!
// NOTE: This does not happen in the HTML FORM element.  It is a problem only with the EDITFORM component.
app.UseAntiforgery();

app.MapStaticAssets();

// NOTE: Adding support for InteractiveServerComponents and InteractiveWebAssemblyComponents 
//       also enables support for InteractiveAuto mode.
app.MapRazorComponents<App>()                    // discovers available components & specifies Root Component for the App.
    .AddInteractiveServerRenderMode()            // configures Interactive Server-side Rendering (interactive SSR) for the app
    .AddInteractiveWebAssemblyRenderMode()       // configures Interactive WebAssembly render mode for the app
    .AddAdditionalAssemblies(typeof(BlazorWebApp2.Client._Imports).Assembly);

// Register the Middleware for API calls.
app.MapControllers();


// Custom Middleware for routing (Part of Demo04Misc examples). 
// NOTE: Check out how the "Routes" component is configured.
app.Use( async ( context, next ) =>
{
    await next( context );

    // Comment out the following lines of code to see the default behaviour for HTTP 404 Not Found.
    // NOTE: check what happens when Enhanced Navigation is ON or OFF
    if ( context.Response.StatusCode == StatusCodes.Status404NotFound && !context.Response.HasStarted )
    {
        context.Response.Redirect( "/Error/404" );
    }
} );


app.Run();

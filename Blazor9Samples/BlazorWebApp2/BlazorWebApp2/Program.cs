using BlazorWebApp2.Components;
using BlazorWebApp2.Components.Demo04Misc.Models;
using BlazorWebApp2.Components.Pages;


var builder = WebApplication.CreateBuilder(args);


//----- Add services to the container.

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

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
// NOTE: Either add the AntiforgeryToken explicitly in the Form,
//       OR configure to add the middleware at the application level in Program.cs
//       Adding both, generates two anti-forgery tokens into the form, which causes conflict!
app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()                    // discovers available components & specifies Root Component for the App.
    .AddInteractiveServerRenderMode()            // configures interactive server-side rendering (interactive SSR) for the app
    .AddInteractiveWebAssemblyRenderMode()       // configures the Interactive WebAssembly render mode for the app
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

using BlazorWebApp2.Components;
using BlazorWebApp2.Components.Demo04Misc.Models;
using BlazorWebApp2.Components.Pages;
using Microsoft.AspNetCore.Mvc;


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

// Register the Services needed to enable ASP.NET Razor Pages (for the Demo17AspNetExamples)
builder.Services.AddRazorPages();

// Register the HttpClient in the DI Services container
// for blazor components to be able to call API endpoints.
// (for example in Demo04Misc/Eg03ApiCall.razor)
builder.Services.AddHttpClient();

// While registering the HttpClient, you can also configure the default BaseAddress for the API endpoints.
// This is also applicable to the Blazor Client Project (in this case the BlazorWebApp2.Client project)
// (for example in Demo11InteractionComponents/Demo11Eg02AutoComplete.razor (in client project)
string? apiUri = builder.Configuration["ApiUri"];
if ( apiUri is not null )
{
    builder.Services
        .AddScoped( sp => new HttpClient { BaseAddress = new Uri( apiUri ) } );
}

// Register the HttpContextAccessor to the DI Services container (if needed)
// for blazor components to be able to access the HTTP Context object when needed 
// (for example in Demo09Errors/Eg04ErrorBoundaryComponent.razor)
// IMPORTANT NOTE: Should be used only in Blazor projects which support Interactive SSR components.
builder.Services.AddHttpContextAccessor();

// Registering the JS InterOp service from the Razor ClassLib project
// as part of the Demo16RazorLibExamples
// NOTE: Remember that IJSRuntime is registered as a Scoped Service.
//       And since ExampleJsInterop receives the IJSRuntime object, it has to be registered as a Scoped Service only!
builder.Services
    .AddScoped<MyRazorClassLib.ExampleJsInterop>();



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
    .AddAdditionalAssemblies(typeof(BlazorWebApp2.Client._Imports).Assembly)
    .AddAdditionalAssemblies(typeof(MyRazorClassLib._Imports).Assembly);        // as part of the Demo16RazorLibExamples

// Register the Middleware for API calls.
app.MapControllers();

// Register support for ASP.NET Razor Pages (for the Demo17AspNetExamples)
app.MapRazorPages();


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


app.MapGet( 
    "/api/Customers", 
    ( ) =>
        Results.Ok( new List<BlazorWebApp2.Shared.Customer>
        {
            new BlazorWebApp2.Shared.Customer { Id = 1, Name = "First Customer" }
            , new() { Id = 2, Name = "Second Customer" }
            , new() { Id = 3, Name = "Third Customer" }
            , new() { Id = 4, Name = "Fourth Customer" }
            , new() { Id = 5, Name = "Fifth Customer" }
        } )
);


app.MapGet(
    "/api/Products",
    ( [FromServices] BlazorWebApp2.Services.BogusGenerators.BogusProductService bogusProductService )
    => Results.Ok(bogusProductService.GenerateProducts() ) 
);


app.MapGet(
    "/api/FilteredProducts",
    ( string filter, 
      [FromServices] BlazorWebApp2.Services.BogusGenerators.BogusProductService bogusProductService )
    =>
    {
        var products = bogusProductService.GenerateProducts();

        var filteredProducts = products
            .Where( p => p.ProductName.ToLower().Contains( filter.ToLower() ) )
            // .OrderBy( c => c.ProductName )
            .ToList();

        return Results.Ok( filteredProducts );
    }
);


app.Run();

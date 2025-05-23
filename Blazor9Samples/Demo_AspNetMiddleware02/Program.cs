var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// --- USE Delegate
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("<html><body>");
    await context.Response.WriteAsync("<p>Hello world from the middleware</p>");

    await next();

    await context.Response.WriteAsync("<p>Hello world again!</p>");
    await context.Response.WriteAsync("</body></html>");
});

// --- USE Delegate
app.Use( async ( context, next ) =>
{
    await context.Response.WriteAsync( "<p>FROM SECOND - BEFORE</p>" );

    await next();

    await context.Response.WriteAsync( "<p>FROM SECOND - AFTER </p>" );
} );


// --- RUN DELEGATE
app.Run(async context =>
{
    await context.Response.WriteAsync("<p>Hello world from THIRD delegate.</p>");
});

app.Run();

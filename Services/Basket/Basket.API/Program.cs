var builder = WebApplication.CreateBuilder(args);

//Add service to the dependency injection Container
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
var app = builder.Build();

//Configure the HTTP request Pipeline.

app.MapCarter();
app.Run();

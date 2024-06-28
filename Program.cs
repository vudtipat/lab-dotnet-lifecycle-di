using LabDenpendencyInjection.Interfaces;
using LabDenpendencyInjection.Middleware;
using LabDenpendencyInjection.Services;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// recreate everytime when called
builder.Services.AddTransient<IMyTransientService, MyService>();
// recreate when new request coming
builder.Services.AddScoped<IMyScopedService, MyService>();
// create once at start
builder.Services.AddSingleton<IMySingletonService, MyService>(); 
builder.Services.AddTransient<MainService>();
builder.Services.AddTransient<SecondService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<Mymiddleware>();

app.UseHttpsRedirection();

int count = 1;
app.MapGet("/", (MainService main) =>
{
    Console.WriteLine($"No {count} coming");
    main.RunMain();
    count++;
    return Results.Ok();    
});

app.Run();

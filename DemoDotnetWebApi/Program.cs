using DemoDotnetWebApi.Interfaces;
using DemoDotnetWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IPasswordGenerator, PasswordGenerator>();
builder.Services.AddTransient<IRandomCharacterGenerator, RandomCharacterGenerator>();
builder.Services.AddTransient<IStringShuffler, StringShuffler>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    });
}

app.UseHttpsRedirection();

app.MapGet("/api/v1/password", (IPasswordGenerator _passwordGenerator) =>
{
    return _passwordGenerator.Generate();
})
.WithName("GetPassword");

app.Run();

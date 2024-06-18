using Microsoft.AspNetCore.Mvc;
using ToUpFamily.Api.Commons;
using ToUpFamily.Api.Infra.Injections;
using ToUpFamily.Api.Infra.Repositories;
using ToUpFamily.Api.Models;

var builder = WebApplication.CreateBuilder(args);

var corsConfig = builder.Configuration.GetSection("Cors").Get<CorsConfig>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfra();

builder.Services.AddCors(x => x.AddPolicy(corsConfig!.CorsPolicy, policy =>
{
  policy
    .WithOrigins([corsConfig.FrontendUrl, corsConfig.BackendUrl])
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsConfig!.CorsPolicy);

app.MapGet("/", () =>
{
  return Results.Ok(corsConfig);
});

app.MapGet("/users", async ([FromServices] IUserRepository _repository) =>
{
  var result = await _repository.GetAllAsync();
  return Results.Ok(result);
})
.WithName("GetUsers")
.WithOpenApi();


app.MapPost("/users", async ([FromServices] IUserRepository _repository, [FromBody] User user) =>
{
  if (await _repository.CreateAsync(user))
  {
    return Results.Ok($"Usuario criado com sucesso.");
  }
  else
  {
    return Results.BadRequest("Houve um erro ao tentar criar o usuário");
  }
})
.WithName("PostUsers")
.WithOpenApi();

app.Run();

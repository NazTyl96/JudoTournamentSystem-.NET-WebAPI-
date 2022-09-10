using Microsoft.OpenApi.Models;
using JTS.Data;
using JTS.Services;
using JTS.Repositories;
using JTS.Interfaces;
using JTS.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "JudoTournamentSystem API", Description = "Making the tournaments easier", Version = "v 0.0.1" });
});

builder.Services.AddSqlServer<Context>(/*your MS SQLServer db*/);

builder.Services.AddScoped<TournamentService>();
builder.Services.AddScoped<ITournamentRepository<Tournament>, TournamentRepository>();
builder.Services.AddScoped<ICompetitorRepository<Competitor>, CompetitorRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
      builder =>
      {
          builder.WithOrigins(
            "http://localhost:3000");
      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "JudoTournamentSystem API v 0.0.1");
    });
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

app.Run();

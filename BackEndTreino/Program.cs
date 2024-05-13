using BackEndTreino.Context;
using BackEndTreino.Extensions;
using BackEndTreino.Filters;
using BackEndTreino.Mappings;
using BackEndTreino.ReposImpl;
using BackEndTreino.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;
using AutoMapper;
using BackEndTreino.Interfaces.Base;
using BackEndTreino.Services;
using BackEndTreino.Interfaces;
using BackEndTreino.DependencyInjection;
using System.Web.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var configuration = builder.Configuration;
var httpConfig = new HttpConfiguration();


builder.Services.AddScoped<ApiLoggingFilter>();

var infra = new DependencyInjection();
infra.AddInfrastructure(builder.Services, builder.Configuration, httpConfig);


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseRouting();

app.UseAuthorization();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

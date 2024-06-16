using Application.DTOs;
using Application.Extensions;
using Application.Helpers;
using Application.RepositoryContracts;
using Application.ServiceContracts;
using Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistance.Context;
using Infrastructure.Persistance.Extensions;
using Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPI.Extensions;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddFluentValidation(v =>
{
    v.ImplicitlyValidateChildProperties = true;
    v.ImplicitlyValidateRootCollectionElements = true;
    v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});


builder.Services.AddHttpLogging(logging => { });

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddExceptionServices();
builder.Services.AddProblemDetails();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseExceptionHandler();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpLogging();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();

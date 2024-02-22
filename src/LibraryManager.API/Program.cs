using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using LibraryManager.API.ViewModels;
using LibraryManager.API.Filters;
using LibraryManager.Infrastructure.Context;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using LibraryManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("LibraryManagementCS");
builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connectionString));

builder.Services
    .AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBookViewModel>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

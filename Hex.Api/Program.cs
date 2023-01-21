using Hex.Application.Interfaces;
using Hex.Application.Repositories;
using Hex.Application.Services;
using Hex.Infra.Data;
using Hex.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HexContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HexContext") ?? throw new InvalidOperationException("Connection string 'HexContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning();

builder.Services.AddTransient<IPessoaService, PessoaService>();
builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();
builder.Services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseApiVersioning();

app.MapControllers();

app.Run();

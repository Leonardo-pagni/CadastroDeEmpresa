using Application.Repositories;
using Application.Services;
using Application.UseCases.Empresa.Handler.Cadastrar;
using Application.UseCases.Empresa.Handler.ListarPaginada;
using Application.UseCases.User.Handler.Cadastrar;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICadastrarEmpresaHandler, CadastrarEmpresaHandler>();
builder.Services.AddScoped<IPesquisarEmpresaPaginadaHandler, PesquisarEmpresaPaginadaHandler>();
builder.Services.AddScoped<ICadastrarUserHandler, CadastrarUserHandler>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddHttpClient<ICnpjService, CnpjService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

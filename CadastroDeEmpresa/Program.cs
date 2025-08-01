using Application.Repositories;
using Application.Services;
using Application.UseCases.Empresa.Handler.Cadastrar;
using Application.UseCases.Empresa.Handler.ListarPaginada;
using Application.UseCases.Login.Handler;
using Application.UseCases.RefreshToken.Handler;
using Application.UseCases.User.Handler;
using Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICadastrarEmpresaHandler, CadastrarEmpresaHandler>();
builder.Services.AddScoped<IPesquisarEmpresaPaginadaHandler, PesquisarEmpresaPaginadaHandler>();
builder.Services.AddScoped<ICadastrarUserHandler, CadastrarUserHandler>();
builder.Services.AddScoped<ILoginHandler, LoginHandler>();
builder.Services.AddScoped<IRefreshTokenHandler, RefreshTokenHandler>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddHttpClient<ICnpjService, CnpjService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = TokenHelper.TokenParameter(builder.Configuration);
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

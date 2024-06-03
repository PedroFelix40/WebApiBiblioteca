using Microsoft.EntityFrameworkCore;
using WebApiBiblioTech.Contexts;
using WebApiBiblioTech.Interfaces;
using WebApiBiblioTech.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configura��o da program

builder.Services.AddDbContext<BiblioTechContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inje��o de dependencia
builder.Services.AddScoped<IGenero, GeneroRepository>();
builder.Services.AddScoped<ITipoUsuario, TipoUsuarioRepository>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();


var app = builder.Build();

// Habilita o CORS
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using webapibibliotech.Contexts;
using webapibibliotech.Interfaces;
using webapibibliotech.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen( options =>
{
    // Usando autentica��o do Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

//Adiciona servi�o de autentica��o JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";


})

//define os parametro de validacao do token 
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // valida quem est� solicitando
        ValidateIssuer = true,

        // Valida quem est� recebendo
        ValidateAudience = true,

        // define se o tempo de expira��o do token ser� validado
        ValidateLifetime = true,

        // forma de criptografia e ainda a valida�ao da chave de autentica��o
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("bibliotech-chave-atenticacao-webapi-dev")),

        // valida o tempo de expiracao do token 
        ClockSkew = TimeSpan.FromMinutes(5),

        // De onde est� vindo 
        ValidIssuer = "webapi.bibliotech",

        // Para onde est� indo
        ValidAudience = "webapi.bibliotech"
    };
});


// Configura��es do BD
builder.Services.AddDbContext<BiblioTechContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inje��o de dependencia
builder.Services.AddScoped<IGenero, GeneroRepository>();
builder.Services.AddScoped<ITipoUsuario, TipoUsuarioRepository>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();
builder.Services.AddScoped<IEmprestimo, EmprestimoRepository>();
builder.Services.AddScoped<ILivro, LivroRepository>();
builder.Services.AddScoped<IResenha, ResenhaRepository>();

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

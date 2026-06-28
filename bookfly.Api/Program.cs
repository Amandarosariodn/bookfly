using System.Reflection;
using System.Text;
using Mapster;
using MapsterMapper;
using bookfly.Application.Shared.UnitOfWork;
using bookfly.Application.Categorias.Services;
using bookfly.Application.Categorias.Services.Interfaces;
using bookfly.Domain.Categorias.Repositories;
using bookfly.Infra.Categorias.Repositories;
using bookfly.Infra.NHibernate;
using bookfly.Infra.UnitOfWork;
using bookfly.Domain.Categorias.Services.Interfaces;
using bookfly.Domain.Categorias.Services;
using bookfly.Application.Livros.Services.Interfaces;
using bookfly.Application.Livros.Services;
using bookfly.Domain.Livros.Services.Interfaces;
using bookfly.Domain.Livros.Services;
using bookfly.Domain.Livros.Repositories;
using bookfly.Infra.Livros.Repositories;
using bookfly.Domain.Usuarios.Services.Interfaces;
using bookfly.Domain.Usuarios.Services;
using bookfly.Domain.Usuarios.Repositories;
using bookfly.Infra.Usuarios.Repositories;
using bookfly.Application.Usuarios.Services.Interfaces;
using bookfly.Application.Usuarios.Services;
using bookfly.Domain.GoogleBooks.Services.Interfaces;
using bookfly.Infra.GoogleBooks.Services;
using bookfly.Application.SeguidorUsuarios.Services.Interfaces;
using bookfly.Application.SeguidorUsuarios.Services;
using bookfly.Domain.SeguidorUsuarios.Repositories;
using bookfly.Infra.SeguidorUsuarios.Repositories;
using bookfly.Domain.SeguidorUsuarios.Services.Interfaces;
using bookfly.Domain.SeguidorUsuarios.Entities;
using bookfly.Domain.SeguidorUsuarios.Services;
using bookfly.Application.EstanteLivros.Services;
using bookfly.Application.EstanteLivros.Services.Interfaces;
using bookfly.Application.Estantes.Services;
using bookfly.Application.Estantes.Services.Interfaces;
using bookfly.Domain.EstanteLivros.Repositories.Interfaces;
using bookfly.Domain.EstanteLivros.Services;
using bookfly.Domain.EstanteLivros.Services.Interfaces;
using bookfly.Domain.Estantes.Repositories.Interfaces;
using bookfly.Domain.Estantes.Services;
using bookfly.Domain.Estantes.Services.Interfaces;
using bookfly.Infra.EstanteLivros.Repositories;
using bookfly.Infra.Estantes.Repositories;
using bookfly.Domain.Avaliacoes.Services.Interfaces;
using bookfly.Domain.Avaliacoes.Services;
using bookfly.Domain.Avaliacoes.Repositories;
using bookfly.Infra.Avaliacoes.Repositories;
using bookfly.Application.Avaliacoes.Services;
using bookfly.Application.Avaliacoes.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using bookfly.Application.Metas.Services.Interfaces;
using bookfly.Application.Metas.Services;
using bookfly.Domain.Metas.Repositories;
using bookfly.Infra.Metas;
using bookfly.Domain.Metas.Services.Interfaces;
using bookfly.Domain.Metas.Services;
using bookfly.Domain.Comunidades.Services.Interfaces;
using bookfly.Domain.Comunidades.Services;
using bookfly.Domain.Comunidades.Repositories.Interfaces;
using bookfly.Infra.Comunidades;
using bookfly.Application.Comunidades.Services.Interfaces;
using bookfly.Application.Comunidades.Services;
using bookfly.Domain.CargosComunidade.Repositories.Interfaces;
using bookfly.Infra.CargosComunidade.Repositories;
using bookfly.Domain.CargosComunidade.Services.Interfaces;
using bookfly.Domain.CargosComunidade.Services;
using bookfly.Application.CargosComunidade.Services.Interfaces;
using bookfly.Application.CargosComunidade.Services;
using bookfly.Domain.Posts.Services.Interfaces;
using bookfly.Domain.Posts.Services;
using bookfly.Domain.Posts.Repositories.Interfaces;
using bookfly.Infra.Posts.Repositories;
using bookfly.Application.Posts.Services.Interfaces;
using bookfly.Application.Posts.Services;

var builder = WebApplication.CreateBuilder(args);

#region Controllers
builder.Services.AddControllers();
#endregion

#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Informe o token JWT."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecuritySchemeReference("Bearer", document),
            new List<string>()
        }
    });
});
#endregion

#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                    .WithOrigins(
    "http://127.0.0.1:5500",
    "http://localhost:5500",
    "http://localhost:4200",
    "http://127.0.0.1:4200",
    "https://bookfly-ivory.vercel.app"
)
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
#endregion

#region Authentication
string? secretKey = builder.Configuration["Jwt:SecretKey"];

if (string.IsNullOrWhiteSpace(secretKey))
    throw new InvalidOperationException("Jwt:SecretKey não configurada.");

string? issuer = builder.Configuration["Jwt:Issuer"];

if (string.IsNullOrWhiteSpace(issuer))
    throw new InvalidOperationException("Jwt:Issuer não configurado.");

string? audience = builder.Configuration["Jwt:Audience"];

if (string.IsNullOrWhiteSpace(audience))
    throw new InvalidOperationException("Jwt:Audience não configurado.");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();
#endregion

#region Mapster
var mapsterConfig = TypeAdapterConfig.GlobalSettings;
mapsterConfig.Scan(Assembly.Load("bookfly.Application"));

builder.Services.AddSingleton(mapsterConfig);
builder.Services.AddScoped<IMapper, ServiceMapper>();
#endregion

#region NHibernate
builder.Services.AddSingleton<NHibernate.ISessionFactory>(_ =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    if (string.IsNullOrWhiteSpace(connectionString))
        throw new InvalidOperationException("Connection string 'DefaultConnection' não configurada.");

    return NHibernateSessionFactory.Create(connectionString);
});

builder.Services.AddScoped<NHibernate.ISession>(sp =>
{
    var factory = sp.GetRequiredService<NHibernate.ISessionFactory>();
    return factory.OpenSession();
});
#endregion

#region Unit of Work
builder.Services.AddScoped<IUnitOfWork, NHibernateUnitOfWork>();
#endregion

#region Domain Services
builder.Services.AddScoped<ICategoriasService, CategoriasService>();
builder.Services.AddScoped<ILivrosService, LivrosService>();
builder.Services.AddScoped<IUsuariosServices, UsuariosService>();
builder.Services.AddScoped<ISeguidorUsuariosService, SeguidorUsuariosService>();
builder.Services.AddScoped<IEstanteLivrosServices, EstanteLivrosServices>();
builder.Services.AddScoped<IEstantesService, EstanteService>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();
builder.Services.AddScoped<IMetasServices, MetasServices>();
builder.Services.AddScoped<IComunidadeService, ComunidadeService>();
builder.Services.AddScoped<ICargoComunidadeService, CargoComunidadeService>();
builder.Services.AddScoped<IPostService, PostService>();
#endregion

#region External Services
builder.Services.AddHttpClient<IGoogleBooksService, GoogleBooksService>();
#endregion

#region Repositories
builder.Services.AddScoped<ICategoriasRepository, CategoriaRepository>();
builder.Services.AddScoped<ILivrosRepository, LivroRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuarioRepository>();
builder.Services.AddScoped<ISeguidorUsuarioRepository, SeguidorUsuarioRepository>();
builder.Services.AddScoped<IEstanteRepository, EstanteRepository>();
builder.Services.AddScoped<IEstanteLivrosRepository, EstanteLivroRepository>();
builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
builder.Services.AddScoped<IMetaRepository, MetaRepository>();
builder.Services.AddScoped<IComunidadeRepository, ComunidadeRepository>();
builder.Services.AddScoped<ICargoComunidadeRepository, CargoComunidadeRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
#endregion

#region Application Services
builder.Services.AddScoped<ICategoriasAppService, CategoriasAppService>();
builder.Services.AddScoped<ILivrosAppServices, LivrosAppServices>();
builder.Services.AddScoped<IUsuariosAppService, UsuariosAppService>();
builder.Services.AddScoped<ISeguidorUsuariosAppService, SeguidorUsuarioAppService>();
builder.Services.AddScoped<IEstanteLivrosAppServices, EstanteLivrosAppService>();
builder.Services.AddScoped<IEstantesAppService, EstantesAppService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<ISenhaService, SenhaService>();
builder.Services.AddScoped<IAvaliacaoAppService, AvaliacaoAppService>();
builder.Services.AddScoped<IMetasAppService, MetaAppService>();
builder.Services.AddScoped<IComunidadeAppService, ComunidadeAppService>();
builder.Services.AddScoped<ICargoComunidadeAppService, CargoComunidadeAppService>();
builder.Services.AddScoped<IPostAppService, PostAppService>();
#endregion

var app = builder.Build();

#region Middleware pipeline

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowFrontend");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers().RequireCors("AllowFrontend");

#endregion

app.Run();

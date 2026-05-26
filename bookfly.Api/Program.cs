using System.Reflection;
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


var builder = WebApplication.CreateBuilder(args);

#region Controllers
builder.Services.AddControllers();
#endregion

#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
builder.Services.AddScoped<ICategoriasService, CategoriasService>();
builder.Services.AddScoped<ILivrosService, LivrosService>();
builder.Services.AddScoped<IUsuariosServices, UsuariosService>();
builder.Services.AddScoped<ISeguidorUsuariosService, SeguidorUsuariosService>();

builder.Services.AddHttpClient<IGoogleBooksService, GoogleBooksService>();
#region Repositories
builder.Services.AddScoped<ICategoriasRepository, CategoriaRepository>();
builder.Services.AddScoped<ILivrosRepository, LivroRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuarioRepository>();
builder.Services.AddScoped<ISeguidorUsuarioRepository, SeguidorUsuarioRepository>();
#endregion

#region Application Services
builder.Services.AddScoped<ICategoriasAppService, CategoriasAppService>();
builder.Services.AddScoped<ILivrosAppServices, LivrosAppServices>();
builder.Services.AddScoped<IUsuariosAppService, UsuariosAppService>();
builder.Services.AddScoped<ISeguidorUsuariosAppService, SeguidorUsuarioAppService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<ISenhaService, SenhaService>();

#endregion
var app = builder.Build();

#region Middleware pipeline
app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();
#endregion

app.Run();

//integração com o front - end
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVercel",
        policy =>
        {
            policy.WithOrigins("https://bookfly-ivory.vercel.app/" ) 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var appFront = builder.Build();

// 2. Ative o CORS antes de outros middlewares de rota
app.UseCors("AllowVercel");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

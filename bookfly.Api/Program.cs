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
    return NHibernateSessionFactory.Create(
        builder.Configuration.GetConnectionString("DefaultConnection")!
    );
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

#region Repositories
builder.Services.AddScoped<ICategoriasRepository, CategoriaRepository>();
builder.Services.AddScoped<ILivrosRepository, LivroRepository>();
#endregion

#region Application Services
builder.Services.AddScoped<ICategoriasAppService, CategoriasAppService>();
builder.Services.AddScoped<ILivrosAppServices, LivrosAppServices>();

#endregion

var app = builder.Build();

#region Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();
#endregion

app.Run();

using Application.Interfaces.ICategoria;
using Application.Interfaces.IClient;
using Application.Interfaces.IExperiencia;
using Application.Interfaces.INivelEstudio;
using Application.Interfaces.IOferta;
using Application.Interfaces.IOfertaCategoria;
using Application.Interfaces.ITipoEstadoPostulacion;
using Application.UseCase.Services.SCategoria;
using Application.UseCase.Services.SClient;
using Application.UseCase.Services.SExperiencia;
using Application.UseCase.Services.SNivelEstudio;
using Application.UseCase.Services.SOferta;
using Application.UseCase.Services.SOfertaCategoria;
using Application.UseCase.Services.STipoEstadoPostulacion;
using Infrastructure.Client;
using Infrastructure.Command;
using Infrastructure.Persistance;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IOfertaCommand, OfertaCommand>();
builder.Services.AddScoped<IOfertaQuery, OfertaQuery>();
builder.Services.AddScoped<IOfertaQueryServices, OfertaQueryServices>();
builder.Services.AddScoped<IOfertaCommandServices, OfertaCommandServices>();

builder.Services.AddScoped<ICategoriaQuery, CategoriaQuery>();
builder.Services.AddScoped<ICategoriaQueryServices, CategoriaQueryServices>();

builder.Services.AddScoped<IExperienciaQuery, ExperienciaQuery>();
builder.Services.AddScoped<IExperienciaQueryServices, ExperienciaQueryServices>();

builder.Services.AddScoped<INivelEstudioQuery, NivelEstudioQuery>();
builder.Services.AddScoped<INivelEstudioQueryServices, NivelEstudioQueryServices>();

builder.Services.AddScoped<ITipoEstadoPostulacionQuery, TipoEstadoPostulacionQuery>();
builder.Services.AddScoped<ITipoEstadoPostulacionQueryServices, TipoEstadoPostulacionQueryServices>();

builder.Services.AddScoped<IOfertaCategoriaCommand, OfertaCategoriaCommand>();
builder.Services.AddScoped<IOfertaCategoriaQuery, OfertaCategoriaQuery>();
builder.Services.AddScoped<IOfertaCategoriaCommandServices, OfertaCategoriaCommandServices>();
builder.Services.AddScoped<IOfertaCategoriaQueryServices, OfertaCategoriaQueryServices>();

builder.Services.AddScoped<IClientGeorefArApiServices, ClientGeorefArApiServices>();

builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IClientGeorefArApi, ClientGeorefArApi>();

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

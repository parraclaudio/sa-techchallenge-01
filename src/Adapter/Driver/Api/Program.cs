using System.Reflection;
using System.Text.Json.Serialization;
using Application.Services;
using Domain.Repositories;
using Domain.Services;
using Infra.Config;
using Infra.Context;
using Infra.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection(nameof(MongoDbConfig)));
builder.Services.AddScoped<AppDbContext>();

var appDbContext = (AppDbContext)builder.Services.BuildServiceProvider().GetService(typeof(AppDbContext));
appDbContext.Map();
var loadDataInDatabase = new CreateData(appDbContext);

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<ICarrinhoDeComprasRepository, CarrinhoDeComprasRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IFilaPedidosRepository, FilaPedidosRepository>();

builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<ICarrinhoDeComprasService, CarrinhoDeComprasService>();
builder.Services.AddTransient<IPedidoService, PedidoService>();


builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v 1.0.0",
        Title = "FIAP - SOFTWARE ARCHITECTURE  - TECH CHALLENGE",
        Description = "Projeto de gestão de pedidos para entrega do Tech Challenge 01",
        Contact = new OpenApiContact
        {
            Name = "Claudio Parra",
            Url = new Uri("https://github.com/parraclaudio")
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//inject automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseReDoc(c =>
    {
        c.DocumentTitle = "FIAP - Tech Challenge";
        c.SpecUrl = "/swagger/v1/swagger.json";
        c.RoutePrefix ="docs";
        c.HideHostname();
        c.HideDownloadButton();
        c.ExpandResponses("all");
    });
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
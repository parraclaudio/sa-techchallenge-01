using System.Text.Json.Serialization;
using Application.Services;
using Domain.Repositories;
using Domain.Services;
using Infra.Context;
using Infra.Repositories;
using Swashbuckle.AspNetCore.ReDoc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection(nameof(MongoDbConfig)));
builder.Services.AddSingleton<AppDbContext>();

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();

builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IProdutoService, ProdutoService>();


builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
using ConversorMoedas.API.Context;
using ConversorMoedas.API.Repositories;
using ConversorMoedas.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<IBancoCentralService, BancoCentralService>(client =>
{
    client.BaseAddress = new Uri("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/");
});

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PgSQLContext>(options =>
    options.UseNpgsql(connection));

builder.Services.AddScoped<IMoedaRepository, MoedaRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

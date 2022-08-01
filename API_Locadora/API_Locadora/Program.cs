using API_Locadora.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Adicionando banco de dados
var connectionStringMySql = builder.Configuration.GetConnectionString("ConnectionMySql");
builder.Services.AddDbContext<LocadoraDbContext>(option => option.UseMySql(
                connectionStringMySql,
                ServerVersion.Parse("MySQL 5.7.37")
    )
);
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

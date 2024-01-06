using Microsoft.EntityFrameworkCore;
using MU.MSSQL.Contexts;
using MU.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
string connectionString = builder.Configuration.GetConnectionString("MU_SQL_DefaultConection");
builder.Services.AddDbContext<MUContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddServices();
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

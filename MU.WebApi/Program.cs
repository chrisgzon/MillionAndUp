using MU.Application;
using MU.Infrastructure;
using MU.WebApi;
using MU.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Million And Up Properties V1"));
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseMiddleware<GloblalExceptionHandlingMiddleware>();

app.UseAuthorization();
app.MapControllers();

app.Run();

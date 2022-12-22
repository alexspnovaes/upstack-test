using Microsoft.OpenApi.Models;
using upstack_test.Interfaces;
using upstack_test.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Upstack-test", Version = "v1" })
);
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRoleService, RoleService>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Upstack-test")
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

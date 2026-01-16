using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Domain.Interfaces.Services;
using ContractApp.Domain.Services;
using ContractApp.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserAddressRepository, UserAddressRepository>();
builder.Services.AddTransient<IPlanRepository, PlanRepository>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserAddressService, UserAddressService>();
builder.Services.AddTransient<IPlanService, PlanService>();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

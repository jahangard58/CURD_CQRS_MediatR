using MediatR;
using Microsoft.EntityFrameworkCore;
using Product_CQRS_MediatR;
using Product_CQRS_MediatR.Context;
using Product_CQRS_MediatR.ProductFeatures.Command.Add;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
});
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IDapperContext, DapperContext>();

builder.Services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddMediatR(typeof(Product_CQRS_MediatR_EntryPoint).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddProductCommandHandler).Assembly));
// Add services to the container.

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

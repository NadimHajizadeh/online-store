using Microsoft.EntityFrameworkCore;
using OnlineStore.Persistanse.EF;
using OnlineStore.Persistanse.EF.ProductGroups;
using OnlineStore.Services.Contracts;
using OnlineStore.Services.ProductGroups;
using OnlineStore.Services.ProductGroups.Contracts;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EFDataContext>(_ =>
    _.UseSqlServer(configuration.GetConnectionString("sqlServer")));
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<ProductGroupService,ProductGroupAppService>();
builder.Services.AddScoped<ProductGroupRepository,EFProductGroupRepository>();


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
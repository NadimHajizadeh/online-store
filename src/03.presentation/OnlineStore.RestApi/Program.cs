using Microsoft.EntityFrameworkCore;
using OnlineStore.Persistanse.EF;
using OnlineStore.Persistanse.EF.ProductGroups;
using OnlineStore.Services.AcountingDocuments;
using OnlineStore.Services.Contracts;
using OnlineStore.Services.ProductGroups;
using OnlineStore.Services.ProductGroups.Contracts;
using OnlineStore.Services.ProductImpotrs.Contracts;
using OnlineStore.Services.Products;
using OnlineStore.Services.Products.Contracts;
using OnlineStore.Specs.Test.ProductSaless.Add;

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
builder.Services.AddScoped<ProductGroupService, ProductGroupAppService>();
builder.Services.AddScoped<ProductGroupRepository, EFProductGroupRepository>();
builder.Services.AddScoped<ProductRepository, EFProductRepository>();
builder.Services.AddScoped<ProductService, ProductAppService>();
builder.Services.AddScoped<ProductImportService, ProductImportAppService>();
builder.Services
    .AddScoped<ProductImportRepository, EFProductImportRepository>();
builder.Services.AddScoped<ProductSalesService, ProductSalesAppService>();
builder.Services.AddScoped<ProductSalesRepository, EFProductSalesRepository>();
builder.Services.AddScoped<AccountingDocumentRepository, EFAccountingDocumentRepository>();
builder.Services.AddScoped<AccountingDocumentService, 
    AccountingDocumentAppService>();







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
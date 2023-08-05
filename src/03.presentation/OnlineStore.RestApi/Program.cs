using Microsoft.EntityFrameworkCore;
using OnlineStore.Persistanse.EF;
using OnlineStore.Persistanse.EF.AccountingDocuments;
using OnlineStore.Persistanse.EF.ProductGroups;
using OnlineStore.Persistanse.EF.ProductImports;
using OnlineStore.Persistanse.EF.Products;
using OnlineStore.Persistanse.EF.ProductSaless;
using OnlineStore.Services.AcountingDocuments;
using OnlineStore.Services.AcountingDocuments.Contracts;
using OnlineStore.Services.Contracts;
using OnlineStore.Services.ProductGroups;
using OnlineStore.Services.ProductGroups.Contracts;
using OnlineStore.Services.ProductImpotrs;
using OnlineStore.Services.ProductImpotrs.Contracts;
using OnlineStore.Services.Products;
using OnlineStore.Services.Products.Contracts;
using OnlineStore.Services.ProductSaless;
using OnlineStore.Services.ProductSaless.Contracts;
using OnlineStore.Services.Shared;

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
builder.Services
    .AddScoped<AccountingDocumentRepository, EFAccountingDocumentRepository>();
builder.Services.AddScoped<AccountingDocumentService,
    AccountingDocumentAppService>();
builder.Services.AddScoped<DateTimeService, DateTimeAppService>();


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
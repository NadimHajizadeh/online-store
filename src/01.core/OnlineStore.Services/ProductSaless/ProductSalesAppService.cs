﻿using OnlineStore.Entities;
using OnlineStore.Services.AcountingDocuments.Contracts;
using OnlineStore.Services.Contracts;
using OnlineStore.Services.Products.Contracts;
using OnlineStore.Services.Products.Exeptions;
using OnlineStore.Services.ProductSaless.Contracts;
using OnlineStore.Services.ProductSaless.Contracts.Dto;
using OnlineStore.Services.ProductSaless.Exceptions;

namespace OnlineStore.Services.ProductSaless;

public class ProductSalesAppService : ProductSalesService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly ProductSalesRepository _repository;

    private readonly AccountingDocumentRepository
        _accountingDocumentRepository;

    private readonly ProductRepository _productRepository;

    private Random _random = new Random();

    public ProductSalesAppService(UnitOfWork unitOfWork,
        ProductSalesRepository repository,
        AccountingDocumentRepository accountingDocumentRepository,
        ProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _accountingDocumentRepository = accountingDocumentRepository;
        _productRepository = productRepository;
    }

    public void Define(AddProductSlaseDto dto)
    {
        var product = _productRepository.FindeById(dto.ProductId);
        StopIfProductNotFound(product);
        StopIfOutOfStock(product, dto.Count);


        var productSales = new ProductSales()
        {
            FactorNumber = new Guid(),
            CustomerName = dto.CustomerName,
            Count = dto.Count,
            Date = DateTime.Now,
            ProductId = dto.ProductId,
            PricePerProduct = dto.PricePerProduct
        };
        var accountingDocument = new AccountingDocument()
        {
            ProductSales = productSales,
            date = productSales.Date,
            DocumentNumber = _random.Next(),
            TotalPrice = productSales.PricePerProduct * productSales.Count
        };

        UpdateProduct(product, dto.Count);
        _repository.Add(productSales);
        _accountingDocumentRepository.Add(accountingDocument);
        _unitOfWork.Complete();
    }

    public List<GetAllProductSalesDto> GetAll()
    {
        return
            _repository.GetAll();
    }

    private void StopIfOutOfStock(Product product, int count)
    {
        if (product.Status == ProductStatus.OutOfStock)
        {
            throw new OutofStockException();
        }

        if (product.Count < count)
        {
            throw new OutofStockException();
        }
    }

    private void StopIfProductNotFound(Product product)
    {
        if (product is null)
        {
            throw new ProuductNotFoundException();
        }
    }

    private void UpdateProduct(Product product, int count)
    {
        product.Count -= count;
        if (product.Count == 0)
        {
            product.Status = ProductStatus.OutOfStock;
        }
        else if (product.Count <= product.LeastCount)
        {
            product.Status = ProductStatus.ReadyToOrder;
        }
    }
}
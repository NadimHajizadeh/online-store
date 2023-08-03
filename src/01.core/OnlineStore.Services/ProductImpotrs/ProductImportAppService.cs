using OnlineStore.Entities;
using OnlineStore.Service.Unit.Test.Products;
using OnlineStore.Services.Contracts;
using OnlineStore.Services.Products.Contracts;
using OnlineStore.Specs.Test.ProductImports.Add;

namespace OnlineStore.Services.ProductImpotrs.Contracts;

public class ProductImportAppService : ProductImportService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly ProductImportRepository _repository;
    private readonly ProductRepository _productRepository;
    private readonly DateTime _date;


    public ProductImportAppService(UnitOfWork unitOfWork,
        ProductImportRepository repository,
        ProductRepository productRepository,
        DateTime? date = null
    )
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _productRepository = productRepository;
        _date = date ?? DateTime.Now;
    }

    public void Define(AddProductImportDto dto)
    {
        var product = _productRepository.FindeById(dto.ProductId);
        StopIfProductNotFound(product);

        var productImport = new ProductImport()
        {
            Count = dto.Count,
            ProductId = dto.ProductId,
            CompenyName = dto.CompenyName,
            FactorNumber = dto.FactorNumber,
            Date = _date
        };

        UpdateProduct(product, dto.Count);
        _repository.Add(productImport);
        _unitOfWork.Complete();
    }

    private  void UpdateProduct(Product product, int count)
    {
        product.Count += count;
        var status = ProductStatus.ReadyToOrder;

        if (product.LeastCount < count)
        {
            status = ProductStatus.Available;
        }

        product.Status = status;
    }

    private  void StopIfProductNotFound(Product product)
    {
        if (product is null)
        {
            throw new ProuductNotFoundException();
        }
    }
}
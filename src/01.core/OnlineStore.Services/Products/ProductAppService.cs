using OnlineStore.Entities;
using OnlineStore.Service.Unit.Test.Products;
using OnlineStore.Services.Contracts;
using OnlineStore.Services.ProductGroups.Contracts;
using OnlineStore.Services.ProductGroups.Exceptions;
using OnlineStore.Services.Products.Contracts;
using OnlineStore.Services.Products.Contracts.Dto;
using OnlineStore.Specs.Test.ProductServiceTest.Add;

namespace OnlineStore.Services.Products;

public class ProductAppService : ProductService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly ProductRepository _repository;
    private readonly ProductGroupRepository _productGroupRepository;

    public ProductAppService(UnitOfWork unitOfWork,
        ProductRepository repository,
        ProductGroupRepository productGroupRepository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _productGroupRepository = productGroupRepository;
    }

    public void Define(AddProductDto dto)
    {
        StopIfInvalidProductGroupId(dto.ProductGroupId);
        StopIfDuplicatedName(dto.Title,dto.ProductGroupId);

        var product = new Product()
        {
            Title = dto.Title,
            LeastCount = dto.LeastCount,
            ProductGroupId = dto.ProductGroupId,
            Status = ProductStatus.OutOfStock
        };

        _repository.Add(product);
        _unitOfWork.Complete();
    }

    public void Remove(int productId)
    {
        var product = _repository.FindeById(productId);

        StopIfProductNotFound(product);

        _repository.Remove(product);
        _unitOfWork.Complete();
    }

    private  void StopIfProductNotFound(Product product)
    {
        if (product is null)
        {
            throw new ProuductNotFoundException();
        }
    }

    private void StopIfDuplicatedName(string title,int ProductGroupId )
    {
        var isDuplicatedName = _repository.IsDuplicatedTitle(title,ProductGroupId);
        if (isDuplicatedName)
        {
            throw new DuplicatedProductNameException();
        }
    }

    private void StopIfInvalidProductGroupId(int id)
    {
        var isExist = _productGroupRepository.IsExistById(id);
        if (!isExist)
        {
            throw new ProuductGroupNotFoundException();
        }
    }
}
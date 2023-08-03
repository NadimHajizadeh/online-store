using OnlineStore.Entities;
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
        StopIfDuplicatedName(dto.Title);

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

    private void StopIfDuplicatedName(string title)
    {
        var isDuplicatedName = _repository.IsDuplicatedTitle(title);
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
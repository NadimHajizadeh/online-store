using OnlineStore.Entities;
using OnlineStore.Services.Contracts;

namespace OnlineStore.Specs.Test.ProductGroupServiceTest.Add;

public class ProductGroupAppService : ProductGroupService
{
    private readonly ProductGroupRepository _repository;
    private readonly UnitOfWork _unitOfWork;

    public ProductGroupAppService(ProductGroupRepository repository,
        UnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public void Define(AddProductGroupDto dto)
    {
        var productGroup = new ProductGroup()
        {
            Name = dto.Name
        };

        _repository.Add(productGroup);
        _unitOfWork.Complete();
    }
}
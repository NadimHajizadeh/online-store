using OnlineStore.Entities;
using OnlineStore.Service.Unit.Test.profuctGroups;
using OnlineStore.Services.Contracts;
using OnlineStore.Services.ProductGroups.Contracts;
using OnlineStore.Services.ProductGroups.Contracts.Dto;
using OnlineStore.Services.ProductGroups.Exceptions;
using OnlineStore.Specs.Test.ProductGroupServiceTest.Update;

namespace OnlineStore.Services.ProductGroups;

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
        StopIfDuplicatedName(dto.Name);

        var productGroup = new ProductGroup()
        {
            Name = dto.Name
        };

        _repository.Add(productGroup);
        _unitOfWork.Complete();
    }

    public void Rename(int productGroupId, RenameProuductGroupDto dto)
    {
        var productGroup = _repository.FindeById(productGroupId);
        StopIfNotFound(productGroup);
        StopIfDuplicatedName(dto.Name);
        
        productGroup.Name = dto.Name;
        
        _repository.Update(productGroup);
        _unitOfWork.Complete();
    }

    private  void StopIfNotFound(ProductGroup? productGroup)
    {
        if (productGroup is null)
        {
            throw new ProuductGroupNotFoundException();
        }
    }

    private void StopIfDuplicatedName(string name)
    {
        var isDuplicatedName = _repository.IsDuplicatedName(name);
        if (isDuplicatedName)
        {
            throw new DuplicatedProductGroupNameException();
        }
    }
}
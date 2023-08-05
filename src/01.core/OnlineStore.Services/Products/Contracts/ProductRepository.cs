using OnlineStore.Entities;
using OnlineStore.Services.Products.Contracts.Dto;

namespace OnlineStore.Services.Products.Contracts;

public interface ProductRepository
{
     void Add(Product product);

     bool IsDuplicatedTitle(string title,int productGroupId);
     void Remove(Product product);
     Product FindeById(int productId);

     List<GetAllProuductsDto> GetAll(ProductOrderBy? orderBy = null
          ,SearchOnDto? dto = null);
}
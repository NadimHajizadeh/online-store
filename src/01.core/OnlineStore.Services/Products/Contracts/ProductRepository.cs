using OnlineStore.Entities;

namespace OnlineStore.Services.Products.Contracts;

public interface ProductRepository
{
     void Add(Product product);

     bool IsDuplicatedTitle(string title);
}
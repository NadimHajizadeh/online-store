using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Persistanse.EF;

namespace OnlineStore.Services.Products.Contracts;

public class EFProductRepository : ProductRepository
{
    private readonly DbSet<Product> _products;

    public EFProductRepository(EFDataContext context)
    {
        _products = context.Set<Product>();
    }

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public bool IsDuplicatedTitle(string title)
    {
        return
            _products.Any(_ => _.Title.ToLower() == title.ToLower());
    }
}
using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Persistanse.EF;

namespace OnlineStore.Specs.Test.ProductSaless.Add;

public class EFProductSalesRepository : ProductSalesRepository
{
    private readonly DbSet<ProductSales> _productSales;

    public EFProductSalesRepository(EFDataContext context)
    {
        _productSales = context.Set<ProductSales>();
    }
    public void Add(ProductSales productSales)
    {
        _productSales.Add(productSales);
    }
}
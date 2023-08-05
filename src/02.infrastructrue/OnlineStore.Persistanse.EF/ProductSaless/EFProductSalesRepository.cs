using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Persistanse.EF;

namespace OnlineStore.Specs.Test.ProductSaless.Add;

public class EFProductSalesRepository : ProductSalesRepository
{
    private readonly DbSet<ProductSales> _productSales;
    private readonly DbSet<Product> _products;

    public EFProductSalesRepository(EFDataContext context)
    {
        _productSales = context.Set<ProductSales>();
        _products = context.Set<Product>();
    }

    public void Add(ProductSales productSales)
    {
        _productSales.Add(productSales);
    }

    public List<GetAllProductSalesDto> GetAll()
    {
        return
            (from productSale in _productSales
                join product in _products on productSale.ProductId equals
                    product.Id
                select new GetAllProductSalesDto()
                {
                    ProductName = product.Title,
                    CustomerName = productSale.CustomerName,
                    Count = productSale.Count,
                    PricePerProduct = productSale.PricePerProduct,
                    Date = productSale.Date,
                    FactorNumber = productSale.FactorNumber
                }).ToList();
    }
}
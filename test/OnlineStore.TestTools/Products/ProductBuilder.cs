using OnlineStore.Entities;

namespace OnlineStore.TestTools.Products;

public class ProductBuilder
{

    private Product _product;

    public ProductBuilder()
    {
        _product = new Product()
        {
            Title = "dummy",
            LeastCount = 10,
            Status = ProductStatus.OutOfStock,
            Count = 0
        };
    }

    public ProductBuilder WithProductGroup(ProductGroup productGroup)
    {
        _product.ProductGroup = productGroup;
        return this;
    }
    
    public ProductBuilder WithTitle(string title)
    {
        _product.Title = title;
        return this;
    }
    
    public ProductBuilder WithCount(int count)
    {
        _product.Count = count;
        return this;
    }
    
    public ProductBuilder WithLeastCount(int count)
    {
        _product.LeastCount = count;
        return this;
    }
    
    public ProductBuilder WithStatus(ProductStatus status)
    {
        _product.Status = status;
        return this;
    }

    public Product Build()
    {
        return
            _product;
    }
    
    
    

}
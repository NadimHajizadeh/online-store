using OnlineStore.Specs.Test.ProductSaless.Add;

namespace OnlineStore.TestTools.ProductSales;

public class AddProductSalesDtoBuilder
{
    private AddProductSlaseDto _dto;

    public AddProductSalesDtoBuilder()
    {
        _dto = new AddProductSlaseDto()
        {
            CustomerName = "dummy",
            PricePerProduct = 1000,
            Count = 5,
        };
    }

    public AddProductSalesDtoBuilder WithProductId(int id)
    {
        _dto.ProductId = id;
        return this;
    }

    public AddProductSalesDtoBuilder WithCount(int count)
    {
        _dto.Count = count;
        return this;
    }

    public AddProductSalesDtoBuilder WithPericePerCount(int price)
    {
        _dto.PricePerProduct = price;
        return this;
    }

    public AddProductSalesDtoBuilder WithCustomerName(string Name)
    {
        _dto.CustomerName = Name;
        return this;
    }

    public AddProductSlaseDto Build()
    {
        return
            _dto;
    }
}
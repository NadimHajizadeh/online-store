﻿using OnlineStore.Entities;

namespace OnlineStore.TestTools.Products.Factories;

public static class ProductFactory
{
    public static Product Generate(ProductGroup productGroup, string title)
    
    {
        return
            new Product()
            {
                ProductGroup = productGroup,
                Title = title,
                LeastCount = 10,
                Status = ProductStatus.OutOfStock,
                Count = 0
            };
    }
}
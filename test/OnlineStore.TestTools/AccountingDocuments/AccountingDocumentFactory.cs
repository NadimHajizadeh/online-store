using OnlineStore.Entities;

namespace OnlineStore.TestTools.AccountingDocuments;

public static class AccountingDocumentFactory
{
    public static AccountingDocument Generate(ProductSales productSales,
        int ducomentNumber)
    {
        return
            new AccountingDocument()
            {
                date = productSales.Date,
                ProductSales = productSales,
                TotalPrice = productSales.Count * productSales.PricePerProduct,
                DocumentNumber = ducomentNumber,
            };
    }
}
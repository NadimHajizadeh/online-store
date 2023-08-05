using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Services.Products.Contracts;
using OnlineStore.Services.Products.Contracts.Dto;

namespace OnlineStore.Persistanse.EF.Products;

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

    public bool IsDuplicatedTitle(string title, int productGroupId)
    {
        return
            _products.Any(_ => _.Title.ToLower() == title.ToLower()
                               && _.ProductGroupId == productGroupId);
    }

    public void Remove(Product product)
    {
        _products.Remove(product);
    }

    public Product FindeById(int productId)
    {
        return
            _products.Find(productId);
    }

    public List<GetAllProuductsDto> GetAll(ProductOrderBy? orderBy,
        SearchOnDto? dto)
    {
        var result = _products.Select(_ => new GetAllProuductsDto()
        {
            ProductCode = _.Id,
            ProductTitle = _.Title,
            GroupName = _.ProductGroup.Name,
            Status = _.Status.ToString(),
            Count = _.Count,
            LeastCount = _.LeastCount
        });

        result = SearchByProductTitle(result, dto.Title);

        result = SearchByGroupName(result, dto.GroupName);

        result = OrderByTitle(result, orderBy);
        
        result = OrderByGroupName(result, orderBy);
        
         


        return result.ToList();
    }

    private static IQueryable<GetAllProuductsDto> OrderByGroupName
    (IQueryable<GetAllProuductsDto> result,
        ProductOrderBy? orderBy)
    {
        if (orderBy is ProductOrderBy.GroupName)
        {
            result = result.OrderBy(_ => _.GroupName);
        }

        return result;
    }

    private static IQueryable<GetAllProuductsDto> OrderByTitle
    (IQueryable<GetAllProuductsDto> result,
        ProductOrderBy? orderBy)
    {
        if (orderBy is ProductOrderBy.Title)
        {
            result = result.OrderBy(_ => _.ProductTitle);
        }

        return result;
    }

    private static IQueryable<GetAllProuductsDto> SearchByGroupName(
        IQueryable<GetAllProuductsDto> result
        , string groupName)
    {
        if (groupName != null)
        {
            result = result.Where(_ => _.GroupName == groupName);
        }

        return result;
    }

    private static IQueryable<GetAllProuductsDto> SearchByProductTitle(
        IQueryable<GetAllProuductsDto> result,
        string? title)
    {
        if (title != null)
        {
            result = result.Where(_ => _.ProductTitle == title);
        }

        return result;
    }
}
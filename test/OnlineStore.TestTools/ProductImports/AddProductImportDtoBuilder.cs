using OnlineStore.Specs.Test.ProductImports.Add;

namespace OnlineStore.TestTools.ProductImports;

public class AddProductImportDtoBuilder
{
    private AddProductImportDto _dto;

    public AddProductImportDtoBuilder()
    {
        _dto = new AddProductImportDto()
        {
            Count = 20,
            FactorNumber = "dummy_factor_number",
            CompenyName = "dummyCo"
        };
    }

    public AddProductImportDtoBuilder WithProductId(int id)
    {
        _dto.ProductId = id;
        return this;
    }

    public AddProductImportDtoBuilder WithFactorNumber(string factorNumber)
    {
        _dto.FactorNumber = factorNumber;
        return this;
    }

    public AddProductImportDtoBuilder WithCompenyName(string compenyName)
    {
        _dto.CompenyName = compenyName;
        return this;
    }

    public AddProductImportDtoBuilder WithCount(int count)
    {
        _dto.Count = count;
        return this;
    }

    public AddProductImportDto Build()
    {
        return
            _dto;
    }
}
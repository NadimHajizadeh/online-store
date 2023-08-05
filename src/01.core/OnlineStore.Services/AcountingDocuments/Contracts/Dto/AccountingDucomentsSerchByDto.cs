namespace OnlineStore.Services.AcountingDocuments.Contracts.Dto;

public class AccountingDucomentsSerchByDto
{
    public Guid? FactorNumber { get; set; } = null;
    public int? DocumentNumber { get; set; } = null;
    public DateTime? FromDate { get; set; } = null;
    public DateTime? TillDate { get; set; } = null;
}
namespace OnlineStore.Services.Contracts;

public interface UnitOfWork
{
    void Complete();
}
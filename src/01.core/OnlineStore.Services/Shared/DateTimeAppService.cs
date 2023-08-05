namespace OnlineStore.Services.Shared;

public class DateTimeAppService : DateTimeService
{
    public DateTime GetTime()
    {
        return DateTime.Now;
    }
}
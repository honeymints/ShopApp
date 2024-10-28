using ShopApp.Application.Common.Services;

namespace ShopApp.Infrastructure.Services;


public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
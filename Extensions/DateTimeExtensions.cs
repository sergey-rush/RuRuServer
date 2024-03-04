using System.Globalization;

namespace RuRuServer.Extensions;

public static class DateTimeExtensions
{
    public static DateTimeOffset ToDateTimeOffset(this string dateTimeString)
    {
        if (!DateTimeOffset.TryParseExact(dateTimeString, "yyyyMMdd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dto))
        {
            throw new ArgumentException(dateTimeString);
        }

        return dto;
    }
}
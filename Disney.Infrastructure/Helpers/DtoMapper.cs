using System.Text.Json;

namespace Disney.Infrastructure.Helpers
{
    public static class DtoMapper
    {
        public static T Mapto<T>(this object value)
        {
            return JsonSerializer.Deserialize<T>(
                JsonSerializer.Serialize(value)
                );
        }
    }
}

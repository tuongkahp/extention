using System.Text.Encodings.Web;
using System.Text.Json;

namespace EncryptExtention
{
    public static class JsonHelper
    {
        private static JsonSerializerOptions options = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public static T Deserialize<T>(string data)
        {
            return JsonSerializer.Deserialize<T>(data);
        }

        public static string Serialize(object data)
        {
            return JsonSerializer.Serialize(data, options);
        }
    }
}

using System.Text.Json.Serialization;

namespace Novel2.Models
{
    public class Entry<TEntry>
    {
        [JsonPropertyName("data")]
        public TEntry Data { get; set; }
    }
}

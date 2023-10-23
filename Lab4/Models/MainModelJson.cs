using Newtonsoft.Json;

namespace Lab4.Models
{
    public class MainModelJson
    {
        [JsonProperty("content")] public ContentModel Content { get; set; }
    }
}
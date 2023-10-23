using Newtonsoft.Json;

namespace Lab4.Models
{
    public class ProfessionalStandardModel
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("content")] public string Content { get; set; }

        [JsonIgnore] public string Code => Content.Split(' ')[0];

        [JsonIgnore] public string Text => Content.Split(' ')[1];
    }
}
using Newtonsoft.Json;

namespace Lab4.Models.Competence
{
    public class CompetenceModel
    {
        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("title")] public string Title { get; set; }
    }
}
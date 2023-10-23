using Newtonsoft.Json;

namespace Lab4.Models
{
    public class CategoryModel
    {

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
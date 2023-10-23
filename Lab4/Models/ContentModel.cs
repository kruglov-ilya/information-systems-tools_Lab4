using Lab4.Models.Section5;
using Newtonsoft.Json;

namespace Lab4.Models
{
    public class ContentModel
    {
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty("section4")]
        public Section4Model Section4 { get; set; }
        [JsonProperty("section5")]
        public Section5Model Section5 { get; set; }


    }
}
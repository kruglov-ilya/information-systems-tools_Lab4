using Newtonsoft.Json;
using System.Linq;

namespace Lab4.Models.Indicators
{
    public class IndicatorModel
    {
        [JsonProperty("content")] public string Content { get; set; }

        [JsonIgnore] public string Title => Content.Split(' ')[0];

        [JsonIgnore]
        public string Text
        {
            get
            {
                var list = Content.Split(' ')
                    .ToList();
                return
                    string.Join(" ", list.GetRange(1, list.Count - 1));
            }
        }
    }
}
using Lab4.Models.Competence;
using Lab4.Models.Indicators;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lab4.Models
{
    public class UniversalCompetencyModel
    {

        [JsonProperty("category")]
        public CategoryModel Category { get; set; }

        [JsonProperty("competence")]
        public CompetenceModel Competence { get; set; }


        [JsonProperty("indicators")]
        public List<IndicatorModel> Indicators { get; set; }

    }
}
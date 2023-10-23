using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lab4.Models
{
    public class Section4Model
    {
        [JsonProperty("professionalStandards")]
        public List<ProfessionalStandardModel> ProfessionalStandardModels { get; set; }

        [JsonProperty("universalCompetencyRows")]
        public List<UniversalCompetencyModel> UniversalCompetencyRows { get; set; }
    }
}
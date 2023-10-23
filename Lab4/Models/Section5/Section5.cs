using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lab4.Models.Section5
{
    public class Section5Model
    {
        [JsonProperty("eduPlan")] public EduPlanModel EduPlan { get; set; }
        [JsonProperty("calendarPlanTable")] public CalendarPlanTableModel PlanTableModel { get; set; }
    }


    public class EduPlanModel
    {
        [JsonProperty("block1")] public Block1Model Block1 { get; set; }
    }


    public class Block1Model
    {
        [JsonProperty("subrows")] public List<SubrowsModel> Subrows { get; set; }
    }

    public class SubrowsModel
    {
        [JsonProperty("index")] public string Index { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("competences")] public List<CompetenceModel> Competences { get; set; }

        [JsonProperty("unitsCost")] public string UnitsCost { get; set; }

        [JsonProperty("terms")] public List<bool> Terms { get; set; }
    }

    public class CompetenceModel
    {
        [JsonProperty("id")] public string Index { get; set; }
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
    }
    public class CalendarPlanTableModel
    {

        [JsonProperty("courses")] public List<CalendarPlanTableCoursesModel> Courses { get; set; }
    }

    public class CalendarPlanTableCoursesModel
    {

        [JsonProperty("weekActivityIds")] public List<string> WeekActivityIds { get; set; }
    }




}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lab4
{
    public partial class TaskFive : Form
    {
        private readonly Form1 _prev;

        public TaskFive(Form1 prev)
        {
            _prev = prev;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HelpChangeForm.GoToMainForm(this, _prev);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            var des = new JsonHelper().Deserealire();
            var subrowsUnit =
                des.Content.Section5.EduPlan.Block1.Subrows.Where(model => model.UnitsCost == item.ToString());
            var dt = new DataTable();
            dt.Columns.Add("Вид обучения ");
            dt.Columns.Add("Продолжительность ");
            dt.Columns.Add("Количество недель ");

            var info = GetCoursesInfo(int.Parse(item.ToString()));

            foreach (var s in info)
            {
                var dr = dt.NewRow();
                dr[0] = s.Title;
                dr[1] = s.Start.ToString("d") + "-" + s.End.ToString("d");
                dr[2] = s.Count;
                dt.Rows.Add(dr);
            }


            dataGridView1.DataSource = dt;
        }

        private void TaskFive_Load_1(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            var des = new JsonHelper().Deserealire();

            var list = new List<string>();
            var distinctUnit = des.Content.Section5.PlanTableModel.Courses.Count;
            //Забыл поставить вместо < <=
            for (int i = 1; i <= distinctUnit; i++)
            {
                list.Add(i.ToString());
            }

            listBox1.DataSource = list;
        }


        private Dictionary<string, string> GetDictionaryNames()
        {
            return new Dictionary<string, string>
            {
                {"Б1", "теоретическое обучение"},
                {"Б2", "практика"},
                {"Э", "промежуточная аттестация"},
                {"К", "каникулы"},
                {"У", "учебная практика"},
                {"П", "производственная практика"},
                {"НИР", "научно-исследовательская работа"},
                {"Д", "государственная итоговая аттестация"}
            };
        }

        private List<WeekActivityOutputModel> GetCoursesInfo(int number)
        {
            var des = new JsonHelper().Deserealire();
            var weekActivityIds = des.Content.Section5.PlanTableModel.Courses[number - 1].WeekActivityIds;


            var prev = weekActivityIds[0];
            var counter = 0;
            var listWeekActivityIds = new List<WeekActivityCountModel>();
            foreach (var current in weekActivityIds)
            {
                if (prev == current)
                {
                    counter++;
                }
                else
                {
                    listWeekActivityIds.Add(new WeekActivityCountModel
                    {
                        Count = counter,
                        Title = prev
                    });
                    counter = 1;
                }

                prev = current;
            }


            var output = new List<WeekActivityOutputModel>();
            var currentDate = new DateTime(2020, 9, 01);
            foreach (var w in listWeekActivityIds)
            {
                var endDate = AddWeeks(w.Count, currentDate);
                output.Add(new WeekActivityOutputModel
                {
                    Start = currentDate,
                    End = endDate,
                    Title = GetDictionaryNames()[w.Title],
                    Count = w.Count
                });
                currentDate = endDate;
            }

            return output;
        }

        private DateTime AddWeeks(int weeks, DateTime currentDate)
        {
            for (int i = 0; i < weeks; i++)
            {
                currentDate = currentDate.AddDays(1);
                while (currentDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    currentDate = currentDate.AddDays(1);
                }
            }

            return currentDate;
        }

        private class WeekActivityCountModel
        {
            public string Title { get; set; }
            public int Count { get; set; }
        }

        private class WeekActivityOutputModel
        {
            public int Count { get; set; }
            public string Title { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lab4
{
    public partial class TaskFour : Form
    {
        private readonly Form _prev;

        public TaskFour(Form prev)
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
            var subrowsTerms = des.Content.Section5.EduPlan.Block1.Subrows.Where(model => model.Terms[int.Parse(item.ToString()) - 1]);
            var dt = new DataTable();
            dt.Columns.Add("Шифр");
            dt.Columns.Add("Название дисциплины");

            foreach (var s in subrowsTerms)
            {
                var dr = dt.NewRow();
                dr[0] = s.Index;
                dr[1] = s.Title;
                dt.Rows.Add(dr);
            }

            dataGridView1.DataSource = dt;
        }

        private void TaskFour_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            var des = new JsonHelper().Deserealire();
            //TODO
            var list = new List<string>();
            var distinctTermCount = des.Content.Section5.EduPlan.Block1.Subrows.Max(x => x.Terms.Count);



            for (int i = 1; i <= distinctTermCount; i++)
            {
                list.Add(i.ToString());
            }


            listBox1.DataSource = list;
        }
    }
}
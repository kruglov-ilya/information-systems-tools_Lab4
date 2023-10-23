using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lab4
{
    public partial class TaskTree : Form
    {
        private readonly Form1 _prev;

        public TaskTree(Form1 prev)
        {
            _prev = prev;
            InitializeComponent();
        }

        private void TaskTree_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            var des = new JsonHelper().Deserealire();

            var list = new List<string>();
            foreach (var s in des.Content.Section5.EduPlan.Block1.Subrows)
            {
                list.Add(s.Title);
            }

            listBox1.DataSource = list;
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
            var subrows = des.Content.Section5.EduPlan.Block1.Subrows.First(model => model.Title == item.ToString());
            var dt = new DataTable();
            dt.Columns.Add("");
            dt.Columns.Add("");


            var dr = dt.NewRow();
            dr[0] = subrows.Index;
            dr[1] = subrows.Title;
            dt.Rows.Add(dr);


            dr = dt.NewRow();
            dr[0] = "Цель";
            dr[1] = subrows.Description;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "Компетенции";
            dr[1] = string.Join(" ", subrows.Competences.Select(x => x.Code));
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "З.Е. ";
            dr[1] = subrows.UnitsCost;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "Семестры";
            dr[1] = string.Join(" ", subrows.Terms.Select(x => x ? "☑" : "◻"));
            dt.Rows.Add(dr);

            dataGridView1.DataSource = dt;
        }
    }
}
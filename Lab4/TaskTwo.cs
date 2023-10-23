using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lab4
{
    public partial class TaskTwo : Form
    {
        private readonly Form1 _prev;

        public TaskTwo(Form1 prev)
        {
            this._prev = prev;
            InitializeComponent();
        }

        private void TaskTwo_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            var des = new JsonHelper().Deserealire();

            var list = des.Content.Section4.UniversalCompetencyRows.Select(s => s.Category.Title).ToList();

            listBox1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HelpChangeForm.GoToMainForm(this, _prev);
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var categoryName = listBox1.SelectedItem.ToString();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            var des = new JsonHelper().Deserealire();
            var dt = new DataTable();
            dt.Columns.Add("Компетенция");
            dt.Columns.Add("Описание");


            foreach (var s in des.Content.Section4.UniversalCompetencyRows.Where(model =>
                model.Category.Title == categoryName
            ))
            {
                var dr = dt.NewRow();
                dr["Компетенция"] = s.Competence.Code;
                dr["Описание"] = s.Competence.Title;
                dt.Rows.Add(dr);

                foreach (var indicator in s.Indicators)
                {
                    dr = dt.NewRow();
                    dr["Компетенция"] = indicator.Title;
                    dr["Описание"] = indicator.Text;
                    dt.Rows.Add(dr);
                }
            }

            dataGridView1.DataSource = dt;
        }
    }
}
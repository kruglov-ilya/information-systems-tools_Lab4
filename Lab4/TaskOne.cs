using System;
using System.Data;
using System.Windows.Forms;

namespace Lab4
{
    public partial class TaskOne : Form
    {
        private readonly Form _prev;

        public TaskOne(Form prev)
        {
            _prev = prev;
            InitializeComponent();
        }

        private void TaskOne_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            var des = new JsonHelper().Deserealire();
            var dt = new DataTable();
            dt.Columns.Add("Код");
            dt.Columns.Add("Название");

            foreach (var s in des.Content.Section4.ProfessionalStandardModels)
            {
                var dr = dt.NewRow();
                dr["Код"] = s.Code;
                dr["Название"] = s.Content;
                dt.Rows.Add(dr);
            }

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HelpChangeForm.GoToMainForm(this, _prev);
        }
    }
}
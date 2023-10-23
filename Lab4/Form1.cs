using System;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HelpChangeForm.ChangeForm(new TaskOne(this), this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HelpChangeForm.ChangeForm(new TaskTwo(this), this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelpChangeForm.ChangeForm(new TaskTree(this), this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HelpChangeForm.ChangeForm(new TaskFour(this), this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HelpChangeForm.ChangeForm(new TaskFive(this), this);
        }
    }
}
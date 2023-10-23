using System;
using System.Windows.Forms;

namespace Lab4
{
    public static class HelpChangeForm
    {
        public static void ChangeForm(Form newForm, Form mainForm)
        {
            if (mainForm == null)
            {
                throw new NullReferenceException();
            }
            mainForm.Hide();
            newForm.Show();


        }

        public static void GoToMainForm(Form thisForm, Form mainForm)
        {
            thisForm.Close();
            mainForm.Show();
        }
    }
}
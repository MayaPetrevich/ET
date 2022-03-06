using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EffecTime
{
    public partial class NewTaskPage : Form
    {
       
        public NewTaskPage()
        {
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            string task = NewTaskBox.Text;
            string timeHours = comboBoxHours.Text;
            string timeMinutes = comboBoxMinutes.Text;
            string tag = comboBoxTags.Text;
            string data = dateTimePicker.Text;
            bool done = false;

            if (NewTaskBox.Text == "")
                NewTaskBox.BackColor = Color.FromArgb(239, 130, 127);
            
            if (comboBoxTags.Text != "" && NewTaskBox.Text != "")
            {
                this.Hide();
                Task Task = new Task(task, timeHours, timeMinutes, tag, data, new Button(), new Button(), done);
                Task.WriteToFile();

                DiaryPage DiaryPage = new DiaryPage();

                this.Hide();
                DiaryPage.Show();
            }
        }

        private void NewTaskBox_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White; 
        }
    }
}

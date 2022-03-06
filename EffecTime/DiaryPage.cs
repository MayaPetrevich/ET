using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EffecTime
{
    public partial class DiaryPage : Form
    {
        string fileName = "file.txt";
        static public List<Task> allTasks = new List<Task>();

        public DiaryPage()
        {
            InitializeComponent();
            panel.Controls.Clear();
            ShowAllTasks(fileName);
        }

        private void ButtonNewTask_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewTaskPage TaskPage = new NewTaskPage();
            TaskPage.Show();
        }

        public void ShowAllTasks(string fileName)
        {
            allTasks.Clear(); //очистка Листа
            panel.Controls.Clear(); 
            if (File.Exists(fileName)==true)
            {
                string[] listOfLines = File.ReadAllLines(fileName); //считывание из файла
                string[] words = null;
                foreach (string line in listOfLines)
                {
                    if (line != "")
                    {
                        words = splitAStringIntoWords(line);
                        Task t = new Task(words[0], words[2], words[3], words[1], words[4], new Button(), new Button(), bool.Parse(words[5]));
                        allTasks.Add(t); //запись в Лист
                    }

                }
            }
            
            for (int i=0; i<allTasks.Count; i++)
            {
                panel.Controls.Add(Line(allTasks[i])); // для пользователя формируются список из Панелей, видимый список заданий
            }

            if (allTasks.Count == 0) //проверочка
             NoTasks();
         
        }

        private void NoTasks()
        {
            this.Opacity = 0;
            Hello Hi = new Hello();
            Hi.Show();
        }

        private string[] splitAStringIntoWords(string line)
        {
            string[] words = line.Split('|');
            return words;
        }

       
        private Panel Line(Task t)
        {
            Panel line = new Panel(); // основная панель
            line.MaximumSize = new Size(453, 200);
            line.AutoSize = true;
            line.AutoSizeMode = AutoSizeMode.GrowOnly;
            line.BorderStyle = BorderStyle.FixedSingle;
            line.Dock = DockStyle.Top;
            line.BackColor = Color.FromArgb(184, 220, 216);

            Label LabelTask = new Label(); // 
            LabelTask.Text = t.task;
            LabelTask.MaximumSize = new Size(383,200);
            if (t.done == true)
            {
                LabelTask.Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Strikeout);
                line.BackColor = Color.FromArgb(0, 168, 107);
            }
            else
                LabelTask.Font = new Font("Segoe UI", 10);
            line.Controls.Add(LabelTask);
            LabelTask.Dock = DockStyle.Top;

            Label LabelTag = new Label();
            LabelTag.Text = t.tag;
            LabelTag.Height = 20;
            LabelTag.Font = new Font("Stencil", 7);
            line.Controls.Add(LabelTag);
            LabelTag.Dock = DockStyle.Bottom;

            Label LabelDataTime = new Label();
            LabelDataTime.Size = new Size(75, 25);
            string curDate = DateTime.Now.ToShortDateString(); // текущая дата
            string day = t.data;
            string time = t.timeHours + ":" + t.timeMinutes;
            DateTime DateNow = DateTime.ParseExact(curDate, "dd.MM.yyyy", null);
            DateTime DateInTask = DateTime.ParseExact(t.data, "dd.MM.yyyy", null);

            if (DateNow > DateInTask)
                line.BackColor = Color.FromArgb(239, 130, 127);
            if (DateNow == DateInTask)
                day = "TODAY";
            if (DateNow == DateInTask.AddDays(1))
                day = "YESTERDAY";
            if (DateNow == DateInTask.AddDays(-1))
                day = "TOMORROW";
            if (time == ":")
                time = "";

            LabelDataTime.Text = day + "\n" + time;
            LabelDataTime.Font = new Font("Stencil", 8);
            line.Controls.Add(LabelDataTime);
            LabelDataTime.Dock = DockStyle.Right;
           
            PictureBox ImageOfTag = new PictureBox();
            ImageOfTag.Size = new Size(25,25);
            ImageOfTag.BackgroundImage = Image.FromFile(adressOfImage(t.tag));
            ImageOfTag.BackgroundImageLayout = ImageLayout.Center;
            line.Controls.Add(ImageOfTag);
            ImageOfTag.Dock = DockStyle.Left;

            Button DoneButton = new Button();
            DoneButton.Size = new Size(25, 25);
            DoneButton.BackgroundImage = Image.FromFile("thumb-up (1).png");
            DoneButton.BackgroundImageLayout = ImageLayout.Center;
            line.Controls.Add(DoneButton);
            DoneButton.Dock = DockStyle.Right;
            DoneButton.FlatStyle = FlatStyle.Flat;
            DoneButton.Tag = t.task;
            DoneButton.Click += DoneButton_Click;

            Button DeleteButton = new Button();
            DeleteButton.Size = new Size(25, 25);
            DeleteButton.BackgroundImage = Image.FromFile("cross.png");
            DeleteButton.BackgroundImageLayout = ImageLayout.Center;
            line.Controls.Add(DeleteButton);
            DeleteButton.Dock = DockStyle.Right;
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.Tag = t.task;
            DeleteButton.Click += DeleteButton_Click;

            return line;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            foreach (var one in allTasks)
                {
                    if (clicked.Tag.ToString() == one.task)
                    {
                        allTasks.Remove(one);
                        break;
                    }
                }

            //Panel thisPanel = clicked.Parent.Parent as Panel;
            //thisPanel.Controls.Remove(clicked.Parent);
            RefreshDiaryPage();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            foreach (var one in allTasks)
            {
                if (clicked.Tag.ToString() == one.task)
                {
                    one.done = true;
                    break;
                }
            }
           //Panel thisPanel = clicked.Parent.Parent as Panel;
            //thisPanel.Controls.Remove(clicked.Parent);
            RefreshDiaryPage();
        }

        private void RefreshDiaryPage()
        {

            File.Delete(fileName);
            foreach (var t in allTasks)
            {
                t.WriteToFile();
            }
            ShowAllTasks(fileName);
        }

        private string adressOfImage(string tag)
        {
            string adress = null;

            if (tag == "STUDY")
                adress = "library-books.png";
            if (tag == "SHOPPING")
                adress = "shopping-cart.png";
            if (tag == "HOBBY")
                adress = "ball-of-basketball.png";
            if (tag == "FRIENDS")
                adress = "fr.png";
            if (tag == "REST")
                adress = "park.png";
            if (tag == "WORK")
                adress = "work-station.png";
            if (tag == "HOME")
                adress = "house-outline.png";
            if (tag == "MEETING")
                adress = "table.png";
            if (tag == "HEALTH")
                adress = "bycicle.png";
            if (tag == "OTHER")
                adress = "paper-plane.png";
            
            return adress;
        }
        
        private void sortTag_CheckedChanged(object sender, EventArgs e)
        {
            allTasks = allTasks.OrderBy(o => o.tag).ToList();
            RefreshDiaryPage();
        }

        private void sortData_CheckedChanged(object sender, EventArgs e)
        {
            allTasks = allTasks.OrderBy(o => o.data).ToList();
            RefreshDiaryPage();
        }
    }
}

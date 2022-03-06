using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace EffecTime
{
    public class Task
    {
        string fileName = "file.txt";
        public string task { set; get; }
        public string tag { set; get; }
        public string timeHours { set; get; }
        public string timeMinutes { set; get; }
        public string data { set; get; }
        public Button DeleteButton { set; get; }
        public Button DoneButton { set; get; }
        public bool done { set; get; }

        public Task(string task, string timeHours, string timeMinutes, string tag, string data, Button DeleteButton, Button DoneButton, bool done)
        {
            this.task = task;
            this.tag = tag;
            this.timeHours = timeHours;
            this.timeMinutes = timeMinutes;
            this.data = data;
            this.DeleteButton = DeleteButton;
            this.DeleteButton.Tag = task;
            this.DoneButton = DoneButton;
            this.done = done;

        }

        public void WriteToFile()
        {
            File.AppendAllText(fileName, task);
            File.AppendAllText(fileName, "|");
            File.AppendAllText(fileName, tag);
            File.AppendAllText(fileName, "|");
            File.AppendAllText(fileName, timeHours);
            File.AppendAllText(fileName, "|");
            File.AppendAllText(fileName, timeMinutes);
            File.AppendAllText(fileName, "|");
            File.AppendAllText(fileName, data);
            File.AppendAllText(fileName, "|");
            File.AppendAllText(fileName, done.ToString());
            File.AppendAllText(fileName, "\r\n");
        }

    }
}

namespace EffecTime
{
    partial class DiaryPage
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiaryPage));
            this.ButtonNewTask = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.sortTag = new System.Windows.Forms.CheckBox();
            this.sortData = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonNewTask
            // 
            this.ButtonNewTask.BackColor = System.Drawing.Color.Teal;
            this.ButtonNewTask.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonNewTask.Image = global::EffecTime.Properties.Resources.new_file;
            this.ButtonNewTask.Location = new System.Drawing.Point(586, 13);
            this.ButtonNewTask.Name = "ButtonNewTask";
            this.ButtonNewTask.Size = new System.Drawing.Size(52, 46);
            this.ButtonNewTask.TabIndex = 0;
            this.ButtonNewTask.UseVisualStyleBackColor = false;
            this.ButtonNewTask.Click += new System.EventHandler(this.ButtonNewTask_Click);
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Location = new System.Drawing.Point(22, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(476, 16);
            this.panel.TabIndex = 3;
            // 
            // sortTag
            // 
            this.sortTag.AutoSize = true;
            this.sortTag.BackColor = System.Drawing.Color.Transparent;
            this.sortTag.Location = new System.Drawing.Point(535, 24);
            this.sortTag.Name = "sortTag";
            this.sortTag.Size = new System.Drawing.Size(46, 17);
            this.sortTag.TabIndex = 4;
            this.sortTag.Text = "tags";
            this.sortTag.UseVisualStyleBackColor = false;
            this.sortTag.CheckedChanged += new System.EventHandler(this.sortTag_CheckedChanged);
            // 
            // sortData
            // 
            this.sortData.AutoSize = true;
            this.sortData.BackColor = System.Drawing.Color.Transparent;
            this.sortData.Location = new System.Drawing.Point(535, 42);
            this.sortData.Name = "sortData";
            this.sortData.Size = new System.Drawing.Size(47, 17);
            this.sortData.TabIndex = 5;
            this.sortData.Text = "date";
            this.sortData.UseVisualStyleBackColor = false;
            this.sortData.CheckedChanged += new System.EventHandler(this.sortData_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(516, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sorting by";
            // 
            // DiaryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EffecTime.Properties.Resources.common_time_management_problems_1280x800;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(677, 468);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sortData);
            this.Controls.Add(this.sortTag);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.ButtonNewTask);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiaryPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonNewTask;
        protected System.Windows.Forms.Panel panel;
        private System.Windows.Forms.CheckBox sortTag;
        private System.Windows.Forms.CheckBox sortData;
        private System.Windows.Forms.Label label1;
    }
}


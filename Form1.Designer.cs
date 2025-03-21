namespace Appointment
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            monthCalendar1 = new MonthCalendar();
            comboBox1 = new ComboBox();
            button1 = new Button();
            label1 = new Label();
            comboBox2 = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.CalendarDimensions = new Size(2, 2);
            monthCalendar1.Location = new Point(93, 94);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Parturi", "Hieronta", "Solarium" });
            comboBox1.Location = new Point(842, 157);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(204, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Font = new Font("JetBrains Mono", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(911, 363);
            button1.Name = "button1";
            button1.Size = new Size(135, 40);
            button1.TabIndex = 2;
            button1.Text = "Varaa!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Space Mono", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(842, 94);
            label1.Name = "label1";
            label1.Size = new Size(204, 28);
            label1.TabIndex = 3;
            label1.Text = "Valitse palvelu:";
            label1.Click += label1_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00" });
            comboBox2.Location = new Point(569, 157);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(204, 23);
            comboBox2.TabIndex = 4;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Space Mono", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(569, 94);
            label2.Name = "label2";
            label2.Size = new Size(168, 28);
            label2.TabIndex = 5;
            label2.Text = "Valitse aika:";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1207, 614);
            Controls.Add(label2);
            Controls.Add(comboBox2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(monthCalendar1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Appointment";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private ComboBox comboBox1;
        private Button button1;
        private Label label1;
        private ComboBox comboBox2;
        private Label label2;
    }
}

namespace Appointment
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Test = new Label();
            SuspendLayout();
            // 
            // Test
            // 
            Test.AutoSize = true;
            Test.Location = new Point(596, 90);
            Test.Name = "Test";
            Test.Size = new Size(36, 21);
            Test.TabIndex = 0;
            Test.Text = "Test";
            Test.Click += label1_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1285, 798);
            Controls.Add(Test);
            Name = "Home";
            Text = "Home";
            Load += Home_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Test;
    }
}
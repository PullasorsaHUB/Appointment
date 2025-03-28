namespace Appointment
{
    partial class Varaukset
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
            label1 = new Label();
            button1 = new Button();
            listBox1 = new ListBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(461, 40);
            label1.Name = "label1";
            label1.Size = new Size(153, 40);
            label1.TabIndex = 0;
            label1.Text = "Varaukset";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(868, 285);
            button1.Name = "button1";
            button1.Size = new Size(203, 62);
            button1.TabIndex = 1;
            button1.Text = "Peru varaus";
            button1.UseVisualStyleBackColor = false;
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.MenuBar;
            listBox1.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.Items.AddRange(new object[] { "Varaus1, Aika, Paikka, jne", "Varaus2, aika, paikka, ...", "Varaus3, aika, paikka, ..." });
            listBox1.Location = new Point(12, 92);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(1059, 158);
            listBox1.TabIndex = 3;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkGray;
            button2.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(641, 285);
            button2.Name = "button2";
            button2.Size = new Size(203, 62);
            button2.TabIndex = 4;
            button2.Text = "Muokkaa varausta";
            button2.UseVisualStyleBackColor = false;
            // 
            // FormTesting
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1083, 584);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "FormTesting";
            Text = "FormTesting";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private ListBox listBox1;
        private Button button2;
    }
}
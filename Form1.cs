namespace Appointment
{
    public partial class Form1 : Form
    {
        private List<string> varatutAjat = new List<string>();
        public Form1()
        {
            InitializeComponent();
            InitUI();
        }


        private void InitUI()
        {
            this.Text = "Ajanvaraus";
            this.Width = 400;
            this.Height = 400;

            MonthCalendar kalenteri = new MonthCalendar { Left = 10, Top = 10 };
            this.Controls.Add(kalenteri);

            Label palveluLabel = new Label { Text = "Valitse palvelu:", Left = 10, Top = 190, Width = 120 };
            this.Controls.Add(palveluLabel);

            ComboBox palveluComboBox = new ComboBox { Left = 10, Top = 210, Width = 150 };
            palveluComboBox.Items.AddRange(new string[] { "Parturi", "Hieronta", "Solarium" });
            this.Controls.Add(palveluComboBox);

            Label aikaLabel = new Label { Text = "Valitse aika:", Left = 10, Top = 240, Width = 120 };
            this.Controls.Add(aikaLabel);

            ListBox aikaListBox = new ListBox { Left = 10, Top = 260, Width = 150, Height = 80 };
            aikaListBox.Items.AddRange(new string[] { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00" ,"16:00", "17:00" });
            this.Controls.Add(aikaListBox);

            Button varaaButton = new Button { Text = "Varaa", Left = 10, Top = 350, Width = 150 };
            this.Controls.Add(varaaButton);

            ListView varausLista = new ListView { Left = 180, Top = 210, Width = 200, Height = 150, View = View.List };
            this.Controls.Add(varausLista);

            varaaButton.Click += (sender, e) =>
            {
                if (palveluComboBox.SelectedItem == null || aikaListBox.SelectedItem == null)
                {
                    MessageBox.Show("Valitse palvelu ja aika.");
                    return;
                }

                string varaus = $"{kalenteri.SelectionStart.ToShortDateString()} - {aikaListBox.SelectedItem} - {palveluComboBox.SelectedItem}";
                if (!varatutAjat.Contains(varaus))
                {
                    varatutAjat.Add(varaus);
                    varausLista.Items.Add(varaus);
                    MessageBox.Show("Aika varattu onnistuneesti!");
                }
                else
                {
                    MessageBox.Show("Aika on jo varattu.");
                }
            };
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

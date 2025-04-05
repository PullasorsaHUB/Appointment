namespace Appointment
{
    public partial class Form1 : Form
    {
        private Dictionary<DateTime,string> varatutAjat = new Dictionary<DateTime,string>();
        public Form1()
        {
            
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
            DateTime selectedDate = e.Start;
            if(!varatutAjat.ContainsKey(selectedDate))
            {
                varatutAjat.Add(selectedDate, "Appintment for user");
                MessageBox.Show($"Appointment added for {selectedDate.ToShortDateString()}");
            }
            else
            {
                MessageBox.Show($"Date {selectedDate.ToShortDateString()} is already booked");
            }
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            // VARAA NAPPI
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mihin paikkaan varataan
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mikä Kellon aikad
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

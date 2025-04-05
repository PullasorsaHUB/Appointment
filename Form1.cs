namespace Appointment
{
    public partial class Form1 : Form
    {
        private Dictionary<DateTime,AjanVaraukset> varatutAjat = new Dictionary<DateTime,AjanVaraukset>();
        public Form1()
        {
            
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public class AjanVaraukset
        {
            public string Time { get; set; }
            public string Service { get; set; } // Default to massage

            public override string ToString()
            {
                return $" Aika: {Time}, Palvelu: {Service}";
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            // VARAA NAPPI
            DateTime selectedDate = monthCalendar1.SelectionStart;

            string selectedTime = comboBox2.SelectedItem?.ToString();
            string selectedService = comboBox1.SelectedItem?.ToString();

            if(string.IsNullOrEmpty(selectedService) || string.IsNullOrEmpty(selectedTime))
            {
                MessageBox.Show("Please select both a service and a time.");
                return;
            }

            DateTime appointmentDateTime = selectedDate.Date.Add(TimeSpan.Parse(selectedTime));

            if(!varatutAjat.ContainsKey(appointmentDateTime))
            {
                varatutAjat[appointmentDateTime] = new AjanVaraukset
                {
                    Time = selectedTime,
                    Service = selectedService
                };

                MessageBox.Show($"Appointment booked\n{appointmentDateTime}\nService: {selectedService}");
            }
            else
            {
                MessageBox.Show("This time slot is already booked!");
            }
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

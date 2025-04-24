using System.Linq;

namespace Appointment
{
    public partial class Form1 : Form
    {
        private List<string> varatutAjat = new List<string>();
        private ListViewItem muokattavaItem = null;
        public Form1(Point location)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = location;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AlustaPalvelu();
            PaivitaAikaValinnat();
            AlustaListView();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            PaivitaAikaValinnat();
        }

        private void AlustaPalvelu()
        {
            comboBox1.Items.Clear();
            string[] kaikkipalvelut = { "Hieronta", "Parturi", "Solarium", "Pyykin Pesu" };
            comboBox1.Items.AddRange(kaikkipalvelut);
            comboBox1.SelectedIndex = 0;
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


        /// <summary>
        /// P‰ivit‰Aikavalinnat
        /// T‰m‰ methodi p‰ivitt‰‰ Comboboxin (alasvetovalikko) ne ajat, jotka ovat vapaana valittulle p‰iv‰lle.
        /// Tyhjent‰‰ vanhat ajat alasvetovalikosta.
        /// Tarkistaa varattujen aikojen listasta, mitk‰ ajat ovat viel‰ vapaita valittuna p‰iv‰n‰.
        /// Lis‰‰ vapaat ajat ComboBoxiin.
        /// Asettaa ensimm‰isen ajan oletusvalinnaksi (jos sellainen on).
        /// </summary>
        private void PaivitaAikaValinnat()
        {
            comboBox2.Items.Clear(); // 1. Tyhjent‰‰ alasvetovalikon

            string valittuPvm = monthCalendar1.SelectionStart.ToShortDateString();
            // 2. Ottaa k‰ytt‰j‰n valitseman p‰iv‰n kalenterista

            string[] kaikkiAjat = { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
            // 3. Lista kaikista mahdollisista varattavista ajoista

            foreach (string aika in kaikkiAjat)
            {
                string varaus = $"{valittuPvm} {aika}"; // Muodostaa esim. "12.4.2025 10:00"
                if (!varatutAjat.Contains(varaus))
                {
                    comboBox2.Items.Add(aika); // Lis‰‰ ajan ComboBoxiin vain jos sit‰ ei ole viel‰ varattu
                }
            }

            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0; // 5. Asettaa ensim‰isen vapaan ajan valituksi oletuksena
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // VARAA NAPPI
            string valittuPvm = monthCalendar1.SelectionStart.ToShortDateString();
            string valittuAika = comboBox2.SelectedItem?.ToString();
            string valittuPalvelu = comboBox1.SelectedItem?.ToString();


            if (string.IsNullOrEmpty(valittuAika) || string.IsNullOrEmpty(valittuPalvelu))
            {
                MessageBox.Show("Valitse sek‰ aika ett‰ palvelu.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string varaus = $"{valittuPvm} {valittuAika}";

            if (varatutAjat.Contains(varaus))
            {
                MessageBox.Show("T‰m‰ aika on jo varattu!", "Varoitus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                varatutAjat.Add(varaus);
                comboBox2.Items.Remove(valittuAika); // Poistetaan valittu aika comboboxista

                ListViewItem item = new ListViewItem(varaus);
                item.SubItems.Add(valittuPalvelu);
                listView1.Items.Add(item);

                MessageBox.Show($"Aika {valittuPvm} {valittuAika} varattu palvelulle: {valittuPalvelu}", "Varaus onnistui", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mihin paikkaan varataan (Palvelu/service)

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mik‰ Kellon aika
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// N‰kee kaikki varatut-ajat Lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var valittu = listView1.SelectedItems[0];
                string aika = valittu.SubItems[0].Text;
                string palvelu = valittu.SubItems[1].Text;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AlustaListView()
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Aika", 150);
            listView1.Columns.Add("Palvelu", 150);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Valitse varaus poistettavaksi.");
                return;
            }

            var valittu = listView1.SelectedItems[0];
            string aika = valittu.SubItems[0].Text;

            if (varatutAjat.Contains(aika))
            {
                varatutAjat.Remove(aika);
                listView1.Items.Remove(valittu);
                PaivitaAikaValinnat();
                MessageBox.Show("Varaus poistettu.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

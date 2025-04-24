using System.Linq;

namespace Appointment
{
    public partial class Form1 : Form
    {
        private List<AjanVaraukset> varatutAjat = new List<AjanVaraukset>();
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
            public DateTime Aika { get; set; }
            public string Palvelu { get; set; } // Default to massage

            public override string ToString()
            {
                return $" Aika: {Aika}, Palvelu: {Palvelu}";
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

                DateTime aikaObjekti = DateTime.Parse(varaus);

                if (aikaObjekti > DateTime.Now && !varatutAjat.Any(v => v.Aika == aikaObjekti))
                {
                    comboBox2.Items.Add(aika);
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
            DateTime aikaObjekti = DateTime.Parse(varaus);
            if (aikaObjekti <= DateTime.Now)
            {
                MessageBox.Show("Et voi varata mennytt‰ aikaa!", "Virheellinen varaus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Jos muokkaus kesken
            if (muokattavaItem != null)
            {
                // Poista vanha varaus listasta
                var vanhaAika = muokattavaItem.SubItems[0].Text;
                var vanhaPalvelu = muokattavaItem.SubItems[1].Text;
                DateTime vanhaDateTime = DateTime.Parse(vanhaAika);

                var poistettava = varatutAjat.FirstOrDefault(v => v.Aika == vanhaDateTime && v.Palvelu == vanhaPalvelu);

                if (poistettava != null)
                    varatutAjat.Remove(poistettava);

                // Lis‰‰ uusi p‰ivitetty varaus
                DateTime uusiAika = DateTime.Parse(varaus);
                varatutAjat.Add(new AjanVaraukset { Aika = uusiAika, Palvelu = valittuPalvelu });

                // P‰ivit‰ listView-rivi
                muokattavaItem.SubItems[0].Text = uusiAika.ToString("dd.MM.yyyy HH:mm");
                muokattavaItem.SubItems[1].Text = valittuPalvelu;

                muokattavaItem = null;
                MessageBox.Show($"Aika {varaus} varattu palvelulle: {valittuPalvelu}", "Varaus onnistui", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (varatutAjat.Any(v => v.Aika == aikaObjekti))
                {
                    MessageBox.Show("T‰m‰ aika on jo varattu!", "Varoitus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                varatutAjat.Add(new AjanVaraukset { Aika = aikaObjekti, Palvelu = valittuPalvelu });

                ListViewItem item = new ListViewItem(aikaObjekti.ToString("dd.MM.yyyy HH:mm"));
                item.SubItems.Add(valittuPalvelu);
                listView1.Items.Add(item);

                MessageBox.Show($"Aika {aikaObjekti:dd.MM.yyyy HH:mm} varattu palvelulle: {valittuPalvelu}", "Varaus onnistui", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            comboBox2.Items.Remove(valittuAika);
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
            string aikaStr = valittu.SubItems[0].Text;
            string palvelu = valittu.SubItems[1].Text;
            DateTime aika = DateTime.Parse(aikaStr);

            var poistettava = varatutAjat.FirstOrDefault(v => v.Aika == aika && v.Palvelu == palvelu);
            if (poistettava != null)
            {
                varatutAjat.Remove(poistettava);
                listView1.Items.Remove(valittu);
                PaivitaAikaValinnat();
                MessageBox.Show("Varaus poistettu.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Valitse varaus muokattavaksi");
                return;
            }

            muokattavaItem = listView1.SelectedItems[0];
            string aikaStr = muokattavaItem.SubItems[0].Text;
            string palvelu = muokattavaItem.SubItems[1].Text;

            // valitut tiedot comboboxiin


            DateTime aika = DateTime.Parse(aikaStr);
            string pvm = aika.ToShortDateString();
            string klo = aika.ToShortDateString();

            // Valitse p‰iv‰ kalenterista (jos eri p‰iv‰)
            monthCalendar1.SetDate(aika);
            PaivitaAikaValinnat(); // P‰ivitt‰‰ vapaat ajat

            // Jos aika ei ole en‰‰ vapaa, silti lis‰t‰‰n comboboxiin tilap‰isesti
            if(!comboBox2.Items.Contains(klo))
                comboBox2.Items.Add(klo);

            comboBox2.SelectedItem = klo;
            comboBox1.SelectedItem = palvelu;

            MessageBox.Show("Muokkaa varattua aikaa samoista lokeroista mist‰ valitsit aikasi ja palvelun t‰m‰n j‰lkeen kun olet vaihtanut 'ajan tai palvelun' paina varaa nappia.",
                "Muokkaustila",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}

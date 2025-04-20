using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointment
{
    public partial class Kirjautuminen : Form
    {
        public Kirjautuminen()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.AcceptButton = button1; // Enter = kirjaudu
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Login Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // yksinkertainen tunnisuts (voit korvata tietokannalla)
            if (username == "admin" && password == "admin")
            {
                Point loginSijainti = this.Location;

                // Piilotetaan kirjautumissivu ja avataan varasulomake
                Form1 varausFormi = new Form1(loginSijainti);
                this.Hide();
                varausFormi.ShowDialog();
                this.Close(); // Sulkee kirjautumisikkunan, kun varus suljetaan
            }
            else
            {
                MessageBox.Show("Virheellinen käyttäjätunnus tai salasana.", "Kirjautuminen epäonnistui", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Username: admin\nPassword: admin", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Username Textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Password textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kirjautuminen_Load(object sender, EventArgs e)
        {

        }
    }
}

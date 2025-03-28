using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointment
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            jonne();
        }

        private void Home_Load(object sender, EventArgs e)
        {

            Test.AutoSize = true;
            Test.Text = "Top Center Text";

            // Calculate X position (Centered)
            int x = (this.ClientSize.Width - Test.Width) / 2;
            int y = 10; // Distance from top (you can change)

            // Set position
            Test.Location = new Point(x, y);

            // Optional: if form resizes, keep it centered
            this.Resize += (s, args) =>
            {
                int newX = (this.ClientSize.Width - Test.Width) / 2;
                Test.Location = new Point(newX, y);
            };
        }
        private void jonne()
        {
            Test.Text = "nigger";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Test.Text = "Nigger";
        }
    }
}

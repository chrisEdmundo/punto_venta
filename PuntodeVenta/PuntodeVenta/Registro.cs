using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntodeVenta
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int r = regUs.agr(textBox6.Text, textBox5.Text, textBox2.Text, textBox4.Text, textBox3.Text);
            if (r > 0)
            {
                MessageBox.Show("usuario registrado ♥");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}

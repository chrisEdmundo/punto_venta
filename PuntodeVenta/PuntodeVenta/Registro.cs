using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                MessageBox.Show("usuario registrado");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            string pattern = "(^[A-Z|a-z]+$)";
            if (Regex.IsMatch(textBox6.Text, pattern) == true)
            {
                label7.ForeColor = Color.LawnGreen;
                label7.Text = "NOMBRE:";
                pictureBox1.Visible = true;
            }
            else
            {
                label7.ForeColor = Color.Red;
                label7.Text = "NOMBRE:";
                pictureBox1.Visible = false;
            }
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            string pattern = "(^[A-Z|a-z]+$)";
            if (Regex.IsMatch(textBox5.Text, pattern) == true)
            {
                label6.ForeColor = Color.LawnGreen;
                label6.Text = "APELLIDO PATERNO:";
                pictureBox1.Visible = true;
            }
            else
            {
                label6.ForeColor = Color.Red;
                label6.Text = "APELLIDO PATERNO:";
                pictureBox1.Visible = false;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string pattern = "(^[A-Z|a-z]+$)";
            if (Regex.IsMatch(textBox2.Text, pattern) == true)
            {
                label3.ForeColor = Color.LawnGreen;
                label3.Text = "APELLIDO MATERNO:";
                pictureBox1.Visible = true;
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "APELLIDO MATERNO:";
                pictureBox1.Visible = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string pattern = "(^[0-9]+$)";
            if (Regex.IsMatch(textBox4.Text, pattern) == true)
            {
                label5.ForeColor = Color.LawnGreen;
                label5.Text = "TELEFONO:";
                pictureBox1.Visible = true;
            }
            else
            {
                label5.ForeColor = Color.Red;
                label5.Text = "TELEFONO:";
                pictureBox1.Visible = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string pattern = "(^[A-Z|a-z|0-9|.|_]+$)";
            if (Regex.IsMatch(textBox3.Text, pattern) == true)
            {
                label4.ForeColor = Color.LawnGreen;
                label4.Text = "CONTRASEÑA:";
                pictureBox1.Visible = true;
            }
            else
            {
                label4.ForeColor = Color.Red;
                label4.Text = "CONTRASEÑA:";
                pictureBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

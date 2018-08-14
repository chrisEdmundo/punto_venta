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
        int validar = 0;
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
            if (validar>0)
            {
                int r = acciones.Agregar_usuario(comboBox1.SelectedIndex, textBox6.Text, textBox5.Text, textBox2.Text, textBox4.Text, textBox3.Text);
                if (r > 0)
                {
                    MessageBox.Show("usuario registrado");
                }
                else
                {
                    MessageBox.Show("ERROR");
                }
                comboBox1.Text = "";
                textBox6.Text = "";
                textBox5.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Un campo esta mal ingresado");
            }
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            string pattern = "(^[A-Z|a-z]+$)";
            if (Regex.IsMatch(textBox6.Text, pattern) == true)
            {
                label7.ForeColor = Color.LawnGreen;
                label7.Text = "NOMBRE:";
                validar += 1;
            }
            else
            {
                label7.ForeColor = Color.Red;
                label7.Text = "NOMBRE:";
                validar *= 0;
            }
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            string pattern = "(^[A-Z|a-z]+$)";
            if (Regex.IsMatch(textBox5.Text, pattern) == true)
            {
                label6.ForeColor = Color.LawnGreen;
                label6.Text = "APELLIDO PATERNO:";
                validar += 1;
            }
            else
            {
                label6.ForeColor = Color.Red;
                label6.Text = "APELLIDO PATERNO:";
                validar *= 0;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string pattern = "(^[A-Z|a-z]+$)";
            if (Regex.IsMatch(textBox2.Text, pattern) == true)
            {
                label3.ForeColor = Color.LawnGreen;
                label3.Text = "APELLIDO MATERNO:";
                validar += 1;
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "APELLIDO MATERNO:";
                validar *= 0;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string pattern = "(^[0-9]+$)";
            if (Regex.IsMatch(textBox4.Text, pattern) == true)
            {
                label5.ForeColor = Color.LawnGreen;
                label5.Text = "TELEFONO:";
                validar += 1;
            }
            else
            {
                label5.ForeColor = Color.Red;
                label5.Text = "TELEFONO:";
                validar *= 0;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string pattern = "(^[A-Z|a-z|0-9|.|_]+$)";
            if (Regex.IsMatch(textBox3.Text, pattern) == true)
            {
                label4.ForeColor = Color.LawnGreen;
                label4.Text = "CONTRASEÑA:";
                validar += 1;
            }
            else
            {
                label4.ForeColor = Color.Red;
                label4.Text = "CONTRASEÑA:";
                validar *= 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void load(object sender, EventArgs e)
        {
            button1.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }
    }
}

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
    public partial class Login : Form
    {
        string usuario = "";
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.contenerdorl.Controls.Count > 0)
                this.contenerdorl.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenerdorl.Controls.Add(fh);
            this.contenerdorl.Tag = fh;
            fh.Show();
        }

        private void enter(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSaveProducts_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            int nivel= acciones.Login(textBox1.Text, textBox2.Text);
            if (nivel > 0)
            {
                Form1 form = new Form1(nivel, usuario);
                acciones.usuario(textBox1.Text, textBox2.Text, form.label1);
                form.Show();
                Login form2 = new Login();
                form2.Close();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
                Registro form = new Registro();
                form.Show();
                Login form2 = new Login();
                form2.Hide();
            
        }

        private void load(object sender, EventArgs e)
        {
            button1.Visible = false;
        }
    }
}

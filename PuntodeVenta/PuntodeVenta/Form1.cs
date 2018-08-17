using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace PuntodeVenta
{
    
    public partial class Form1 : Form
    {
        int nivel;
        string usuario;
        public Form1(int nivel,string usuario)
        {
            InitializeComponent();
            this.nivel = nivel;
            this.usuario = usuario;
        }
        //[Dllimport("user32")]
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width ==170)
            {
                MenuVertical.Width = 55;
            }
            else
            {
                MenuVertical.Width = 170;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox6.Visible = true;
            pictureBox5.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pictureBox6.Visible = false;
            pictureBox5.Visible = true;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContenerdo_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.panelContenerdo.Controls.Count > 0)
                this.panelContenerdo.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenerdo.Controls.Add(fh);
            this.panelContenerdo.Tag = fh;
            fh.Show();
        }
        
        private void btnVenta_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Ventas(label1.Text));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new producto());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Reportes());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Inventario());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Login());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Recibos());
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Registro());

        }

        private void Form1Load(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Ventas(label1.Text));
            if (nivel == 1)
            {
                button3.Visible = false;
                button4.Visible = false;

            }
            if (nivel == 2)
            {
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = false;
            }
            if (nivel == 3)
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = false;

            }
        }
        int posY = 0;
        int posX =0;
        private void BarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;

            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}

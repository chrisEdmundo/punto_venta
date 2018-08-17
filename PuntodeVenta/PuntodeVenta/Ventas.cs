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
    public partial class Ventas : Form
    {
        List<int> articulos = new List<int>();
        float total = 0;
        string usuario;
        public Ventas(string user)
        {
            InitializeComponent();
            this.usuario = user;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string pattern = "(^[0-9]+$)";
            if (Regex.IsMatch(textBox1.Text, pattern) == true)
            {
                if (int.Parse(textBox1.Text) > 0)
                {
                    float precio = acciones.Vender(textBox1.Text, listView1, articulos);
                    if (precio > 0)
                    {
                        total += precio;
                        label6.Text = total + "";
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("el articulo no esta disponible");
                    }
                }
            }
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            acciones.busqueda_codigos(listView2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int r = 0;
            foreach(int articulo in articulos)
            {
                r= acciones.agregar_movimientos(articulo,usuario);
            }
            if (r > 0)
            {
                MessageBox.Show("venta registrada");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}

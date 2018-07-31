using MySql.Data.MySqlClient;
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
    public partial class producto : Form
    {
        public producto()
        {
            InitializeComponent();
        }

        private void producto_Load(object sender, EventArgs e)
        {
            acciones.buscar(dataGridView1, listBox1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSaveProducts_Click(object sender, EventArgs e)
        {
            acciones.agregar(listBox1.SelectedIndex, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            acciones.buscar(dataGridView1, listBox1);
        }

        private void btnDeleteProducts_Click(object sender, EventArgs e)
        {
            acciones.borrar(dataGridView1.SelectedRows);
        }
    }
}

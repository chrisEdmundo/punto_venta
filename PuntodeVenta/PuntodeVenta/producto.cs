﻿using MySql.Data.MySqlClient;
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
        string nombre = "";
        string marca = "";
        int codigo = 0;
        int celda = 0;
        string nombre_edit = "";
        string marca_edit = "";
        string descripcion = "";
        string unidades = "";
        string precio = "";
        string code = "";

        public producto()
        {
            InitializeComponent();
        }

        private void producto_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = acciones.BuscarProductos();
            acciones.Categoria(comboBox1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSaveProducts_Click(object sender, EventArgs e)
        {
            int r = acciones.Agregar_producto(comboBox1.SelectedIndex, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            if (r > 0)
            {
                dataGridView1.DataSource = acciones.BuscarProductos();
            }
            comboBox1.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
        }

        private void btnDeleteProducts_Click(object sender, EventArgs e)
        {
            DialogResult confirmar;
            confirmar = MessageBox.Show("¿seguro que quieres borrar [" + nombre + " " + marca + "]?", "borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirmar == DialogResult.Yes)
            {
                int r = acciones.Borrar(codigo);
                dataGridView1.DataSource = acciones.BuscarProductos();
            }
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nombre = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            marca = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            codigo = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
            celda = dataGridView1.CurrentRow.Index;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            nombre_edit = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            marca_edit = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            descripcion = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            unidades = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            precio = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            code = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            int retorno = acciones.modificar(nombre_edit,marca_edit,descripcion,unidades,precio,code);
        }
    }
}

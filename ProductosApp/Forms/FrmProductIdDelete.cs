using Domain.Entities;
using Infraestructure.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosApp.Forms
{
    public partial class FrmProductIdDelete : Form
    {
        public ProductoModel ProductoModel { get; set; }
        public Producto Producto { get; set; }
        public FrmProductIdDelete()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                if (!int.TryParse(txtId.Text, out id))
                {
                    MessageBox.Show("Error, el formato del id no es correcto.");
                }

                Producto producto = new Producto();
                producto.Id = id;
                ProductoModel.Delete(producto);
                Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}

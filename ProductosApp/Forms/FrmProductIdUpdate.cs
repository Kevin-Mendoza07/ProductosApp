using Domain.Entities;
using Domain.Enums;
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
    public partial class FrmProductIdUpdate : Form
    {
        public ProductoModel ProductoModel { get; set; }

        private ProductoModel productoModel;
        public FrmProductIdUpdate()
        {
            productoModel = new ProductoModel();
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
                productoModel.GetAll();
                
                FrmProductUpdater frmProductUpdater = new FrmProductUpdater();
                frmProductUpdater.ProductoModel = productoModel;
                frmProductUpdater.ShowDialog();
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmProductIdUpdate_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}

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
    public partial class FrmProducto : Form
    {
        public ProductoModel ProductoModel { get; set; }
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            cmbMeasureUnit.Items.AddRange(Enum.GetValues(typeof(UnidadMedida))
                                              .Cast<object>().ToArray()
                                         );
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try {

                if (string.IsNullOrEmpty(txtName.Text) ||
             string.IsNullOrWhiteSpace(txtDesc.Text) ||
             nudExist.Value == 0 ||
             nudPrice.Value == 0 ||
             string.IsNullOrWhiteSpace(cmbMeasureUnit.Text))
                {
                    throw new ArgumentException("Error debe llenar todos los campos");
                    
                }
                

                Producto p = new Producto()
                {
                    Id = ProductoModel.GetLastProductoId() + 1,
                    Nombre = txtName.Text,
                    Descripcion = txtDesc.Text,
                    Existencia = (int)nudExist.Value,
                    Precio = nudPrice.Value,
                    FechaVencimiento = dtpCaducity.Value,
                    UnidadMedida = (UnidadMedida)cmbMeasureUnit.SelectedIndex
                };

                ProductoModel.Add(p);

                Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var FrmProductManage = new FrmProductManage();
            FrmProductManage.Show();
            this.Close(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
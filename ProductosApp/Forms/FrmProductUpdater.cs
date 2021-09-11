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
    public partial class FrmProductUpdater : Form
    {
        public ProductoModel ProductoModel { get; set; }
        public FrmProductUpdater()
        {
            InitializeComponent();
        }
        Producto p;
        private void btnOk_Click(object sender, EventArgs e)
        {
            p = new Producto()
            {
                Id = ProductoModel.GetLastProductoId() + 1,
                Nombre = txtName.Text,
                Descripcion = txtDesc.Text,
                Existencia = (int)nudExist.Value,
                Precio = nudPrice.Value,
                FechaVencimiento = dtpCaducity.Value,
                UnidadMedida = (UnidadMedida)cmbMeasureUnit.SelectedIndex
            };

            ProductoModel.Update(p);

            Dispose();
        }

        private void FrmProductUpdater_Load(object sender, EventArgs e)
        {
            cmbMeasureUnit.Items.AddRange(Enum.GetValues(typeof(UnidadMedida))
                                              .Cast<object>().ToArray()
                                         );
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}

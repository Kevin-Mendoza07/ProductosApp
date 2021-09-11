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
    public partial class FrmProductManage : Form
    {
        private ProductoModel productoModel;
        private Producto producto;
        public FrmProductManage()
        {
            productoModel = new ProductoModel();
            producto = new Producto();
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFinder.SelectedIndex)
            {
                case 0:
                    pnlId.Visible = true;
                    pnlMeasureUnit.Visible = false;
                    pnlPriceRange.Visible = false;
                    pnlCaducity.Visible = false;
                    break;
                case 1:
                    pnlId.Visible = false;
                    pnlMeasureUnit.Visible = true;
                    pnlPriceRange.Visible = false;
                    pnlCaducity.Visible = false;
                    break;
                case 2:
                    pnlId.Visible = false;
                    pnlMeasureUnit.Visible = false;
                    pnlPriceRange.Visible = true;
                    pnlCaducity.Visible = false;
                    break;
                case 3:
                    pnlId.Visible = false;
                    pnlMeasureUnit.Visible = false;
                    pnlPriceRange.Visible = false;
                    pnlCaducity.Visible = true;
                    break;
            }
        }

        private void FrmProductManage_Load(object sender, EventArgs e)
        {
            cmbMeasureUnit.Items.AddRange(Enum.GetValues(typeof(UnidadMedida))
                                              .Cast<object>().ToArray()
                                         );
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmProducto frmProducto = new FrmProducto();
            frmProducto.ProductoModel = productoModel;
            frmProducto.ShowDialog();

            rtbProductView.Text = productoModel.GetProductosAsJson();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmProductIdUpdate frmProductIdUpdate = new FrmProductIdUpdate();
            frmProductIdUpdate.ProductoModel = productoModel;
            frmProductIdUpdate.ShowDialog();

            rtbProductView.Text = productoModel.GetProductosAsJson();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FrmProductIdDelete frmProductIdDelete = new FrmProductIdDelete();
            frmProductIdDelete.ProductoModel = productoModel;
            frmProductIdDelete.ShowDialog();
            

            rtbProductView.Text = "El producto ha sido eliminado.";
        }
    }
}

using Domain.Entities;
using Domain.Enums;
using Infraestructure.Productos;
using Newtonsoft.Json;
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

        public Producto Pro { get; set;  }
       
        private ProductoModel productoModel;
        private Producto producto;
        public FrmProductManage()
        {

            Pro = new Producto(); 
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

        private void btnBuscarId_Click(object sender, EventArgs e)
        {
            try
            {

                int id;
                id = int.Parse(txtId.Text);

                //if (productoModel.GetProductoById(id) == null)
                //{
                //    MessageBox.Show("Error, este producto no existe en el inventario", "Mensaje de Error",
                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //else
                //{
                //  Pro= productoModel.GetProductoById(id);
                //  rtbProductView.Text = "El producto se encuentra"; 
                //  rtbProductView.Text = productoModel.GetProductosAsJson();


                Producto p = productoModel.GetProductoById(id);
                if (p != null)
                {
                    rtbProductView.Text = $"El producto con ID: {id} es: \n";
                    rtbProductView.Text += JsonConvert.SerializeObject(p);
                    txtId.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("No se ha encontrado un producto con ese codigo", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                    {

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            }

        private void rtbProductView_TextChanged(object sender, EventArgs e)
        {

        }


       
    }
}
    




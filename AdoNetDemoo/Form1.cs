using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemoo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoodProduct();
        }

        private void LoodProduct()
        {
            dgv_Product.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                StockAmount = Convert.ToInt16(tbxStockAmount.Text),
                UnitPrice = Convert.ToDecimal(tbxUnitePrice.Text)
            });

            LoodProduct();
            MessageBox.Show("Added a product");
        }

       

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt16(dgv_Product.CurrentRow.Cells[0].Value),
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitePrice.Text),
                StockAmount = Convert.ToInt16(tbxStockAmount.Text)
            };
            _productDal.Add(product);
            LoodProduct();
            MessageBox.Show("Update a product");
        }

        private void dgv_Product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxName.Text = dgv_Product.CurrentRow.Cells[1].Value.ToString();
            tbxUnitePrice.Text = dgv_Product.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmount.Text = dgv_Product.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(dgv_Product.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            LoodProduct();
            MessageBox.Show("Delete a product");
        }
    }
}

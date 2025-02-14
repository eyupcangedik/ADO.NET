﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
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
            dgwStyle();
        }

        public void dgwStyle()
        {
            dgwProducts.DataSource = _productDal.GetAll();
            dgwProducts.Font = new Font("Arial", 11);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxProductNameAdd.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceAdd.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountAdd.Text),
            });
            MessageBox.Show("Product Added!");
            dgwStyle();
        }


        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxProductNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxProductNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),
            };
            _productDal.Update(product);
            MessageBox.Show("Product Updated!");
            dgwStyle();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            MessageBox.Show("Product Deleted!");
            dgwStyle();
        }
    }
}

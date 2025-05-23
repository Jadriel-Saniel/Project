﻿using ProjectForm.Model.DTOs.ProductDtos;
using ProjectForm.Model.DTOs;
using ProjectForm.Presenter;
using ProjectForm.View.IView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectForm
{
    //part 3 of the tutorial
    //https://www.youtube.com/watch?v=9LdU5zA5agA&list=PLcDvtJ2MXvhy_YrXdO4VXqZBOADCRJhSc&index=4
    public partial class Product : Form, IProductView
    {
        private readonly ProductPresenter? presenter;
        private readonly BindingSource _bindingSource;
        public Product()
        {
            InitializeComponent();
            _bindingSource = new BindingSource();
            presenter = new ProductPresenter(this);
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = _bindingSource;
            dgvProduct.CellContentClick += DataGridProductView_CellContentClick;
            dgvProduct.RowPostPaint += DataGridProductView_RowPostPaint;    
            btnAdd.Click += (s, e) => AddClicked?.Invoke(this, EventArgs.Empty);
            txtSearch.TextChanged += ProductSearched_TextChanged;
        }

        public event EventHandler<DataGridViewCellEventArgs>? DeleteClicked;
        public event EventHandler<DataGridViewCellEventArgs>? EditClicked;
        public event EventHandler<DataGridViewRowPostPaintEventArgs>? RowNumber;
        public event EventHandler? ProductSearched;
        public event EventHandler? AddClicked;
        public string SearchText => txtSearch.Text.ToLower();
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (presenter != null)
        //    {
        //        ProductModule productModule = new ProductModule(presenter);
        //        productModule.ShowDialog();
        //    }

        //}
        public void DisplayProductList(List<GetAllProductDto> productList)
        {
            _bindingSource.DataSource = productList;
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                row.Cells["Edit"].Value = Properties.Resources.edit;
                row.Cells["Delete"].Value = Properties.Resources.delete;
            }
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        private void DataGridProductView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            var gridView = sender as DataGridView;
            if (gridView == null || e.RowIndex < 0) return;

            if (gridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                DeleteClicked?.Invoke(sender, e);

            }

            if (gridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                EditClicked?.Invoke(sender, e);
            }
        }
        private void ProductSearched_TextChanged(object? sender, EventArgs e)
        {
            ProductSearched?.Invoke(sender, e);
        }
        private async void Product_Load(object sender, EventArgs e)
        {
            if(presenter != null)
            {
                await presenter.LoadProductList();
            }           
        }
        private void DataGridProductView_RowPostPaint(object? sender, DataGridViewRowPostPaintEventArgs e)
        {
            var gridView = sender as DataGridView;
            if (gridView == null || e.RowIndex < 0) return;
            RowNumber?.Invoke(sender, e);

        }
    }
}

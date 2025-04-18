﻿using ProjectForm.Model.DTOs;
using ProjectForm.Presenter;
using ProjectForm.View.IView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectForm
{
    //Part 2 of the tutorial
    // https://youtu.be/bwLZAB8VT2Y?si=2yvkCOgqmHRAri6S
    public partial class CategoryModule : Form, ICategoryModuleView
    {
        private CategoryModulePresenter? presenter;
        private readonly CategoryPresenter presenterPresenter;
        public CategoryModule(CategoryPresenter presenterPresenter)
        {
            InitializeComponent();
            btnSave.Click += (s, e) => SaveClicked?.Invoke(this, EventArgs.Empty);
            btnUpdate.Click += (s, e) => UpdateClicked?.Invoke(this, EventArgs.Empty);
            btnClear.Click += (s, e) => ClearClicked?.Invoke(this, EventArgs.Empty);
            this.presenterPresenter = presenterPresenter;
        }

        public event EventHandler? SaveClicked;
        public event EventHandler? UpdateClicked;
        public event EventHandler? ClearClicked;

        public string CategoryName
        {
            get => txtCategoryName.Text;
            set => txtCategoryName.Text = value;
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ClearMessage()
        {
            showMessageLabel.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CategoryModule_Load(object sender, EventArgs e)
        {
            presenter = new CategoryModulePresenter(this, presenterPresenter);
        }
    }
}

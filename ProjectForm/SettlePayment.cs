﻿using System;
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
    public partial class SettlePayment : Form
    {
        public SettlePayment()
        {
            InitializeComponent();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.' || txtCash.Text.Contains(".")))
            {
                e.Handled = true; // Block invalid characters

            }
        }
    }

}
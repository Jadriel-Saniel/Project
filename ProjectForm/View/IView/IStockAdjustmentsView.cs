﻿using ProjectForm.Model.DTOs.StockDtos;
using ProjectForm.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForm.View.IView
{
    public interface IStockAdjustmentsView
    {
        public string SelectedItem { get; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string ProductCode {  get; set; }
        public int ProductQuantity { get; set; }
        
        event EventHandler SelectedItemCombo;
        event EventHandler<DataGridViewCellEventArgs>? SelectedClicked;
        event EventHandler<DataGridViewRowPostPaintEventArgs>? RowNumber;
        event EventHandler? SaveClicked;
        public void DisplayStocks(List<GetAllStockAdjustmentsDto> stocks);
    }
}

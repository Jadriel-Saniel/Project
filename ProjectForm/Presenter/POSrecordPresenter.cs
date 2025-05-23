﻿using ProjectForm.Model.DTOs.SalesDetailDtos;
using ProjectForm.Model.DTOs;
using ProjectForm.Model.DTOs.ProductDtos;
using ProjectForm.Model.DTOs.StockRecordDtos;
using ProjectForm.View.IView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProjectForm.Presenter
{
    public class POSrecordPresenter
    {
        private readonly IPOSrecordView _view;
        private readonly POSrecord _pOSrecord;
        private readonly HttpClient _httpClient;
        public POSrecordPresenter(IPOSrecordView view, POSrecord pOSrecord)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7014/api") };
            _view = view;
            _pOSrecord = pOSrecord;
            _view.RowNumber += OnRowNumber;
        }
        public async Task LoadDataAsync(string name, DateOnly startDate, DateOnly endDate, string selecteditem)
        {
            
            if(startDate > endDate || endDate < startDate)
            {
                MessageBox.Show("Invalid Date");
                return;
            }

            string dateTo = startDate.ToString("MM-dd-yyyy");
            string dateFrom = endDate.ToString("MM-dd-yyyy");
            string newSelectedItem = selecteditem.Replace(" ", "");
            
            if (name == "btnLoad")
            {
                if (selecteditem == string.Empty)
                {
                    MessageBox.Show("Please select sort type.");
                    return;
                }
                //this is for top selling items
                var data = await LoadTopSellingAsync(dateTo, dateFrom, newSelectedItem);
                _view.DisplayTopSellingItems(data); 
                 _pOSrecord.selectedComboBox= string.Empty;

            }
            else if(name == "btnLoadSolditem")
            {
                //this is for sold items
                var data = await LoadSoldItemsAsync(dateTo, dateFrom);
                _view.DisplaySoldItems(data);
                _pOSrecord.selectedComboBox = string.Empty;
            }
            else if(name == "btnLoadstockin")
            {
                //this is for stock in history
                var data =  await LoadStockInHistoryAsync(dateTo, dateFrom);
                _view.DisplayStockInHistory(data);
                _pOSrecord.selectedComboBox = string.Empty;
            }
        }
        public async Task<List<GetSalesByQtyDto>> LoadTopSellingAsync(string startDate, string endDate, string selectedItem)
        {
            try
            {
                var res = await _httpClient.GetAsync($"/Sales/TopSelling/FilteredBY?startDate={startDate}&endDate={endDate}&action={selectedItem}");

                res.EnsureSuccessStatusCode();

                var sales = await res.Content.ReadFromJsonAsync<List<GetSalesByQtyDto>>();

                if (sales == null)
                {
                    return new List<GetSalesByQtyDto>();
                }

                return sales;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
                return new List<GetSalesByQtyDto>();
                
            }
        }
        public async Task<List<GetSalesByQtyDto>> LoadSoldItemsAsync(string startDate, string endDate)
        {
            try
            {
                var res = await _httpClient.GetAsync($"/Sales/All/FilteredBy?startDate={startDate}&endDate={endDate}");

                res.EnsureSuccessStatusCode();

                var sales = await res.Content.ReadFromJsonAsync<List<GetSalesByQtyDto>>();

                if (sales == null)
                {
                    return new List<GetSalesByQtyDto>();
                }

                return sales;

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
                return new List<GetSalesByQtyDto>();
            }
        }
        public async Task<List<GetAllCriticalProductsDto>> LoadCriticalItemAsync()
        {
            try
            {
                var res = await _httpClient.GetAsync($"/Products/Critical/all");

                res.EnsureSuccessStatusCode();

                var criticalProducts = await res.Content.ReadFromJsonAsync<List<GetAllCriticalProductsDto>>();

                if (criticalProducts == null)
                {
                    return new List<GetAllCriticalProductsDto>();
                }

                return criticalProducts;

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
                return new List<GetAllCriticalProductsDto>();
            }
        }
        public async Task<List<GetInventoryListDto>> LoadInventoryListAsync()
        {
            try
            {
                var res = await _httpClient.GetAsync($"/Products/Inventory");

                res.EnsureSuccessStatusCode();

                var criticalProducts = await res.Content.ReadFromJsonAsync<List<GetInventoryListDto>>();

                if (criticalProducts == null)
                {
                    return new List<GetInventoryListDto>();
                }

                return criticalProducts;

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
                return new List<GetInventoryListDto>();
            }
        }
        public async Task<List<GetStockInHistoryDto>> LoadStockInHistoryAsync(string startDate, string endDate)
        {
            try
            {
                var res = await _httpClient.GetAsync($"/StockRecords/History/FilteredBy?startDate={startDate}&endDate={endDate}");

                res.EnsureSuccessStatusCode();

                var sales = await res.Content.ReadFromJsonAsync<List<GetStockInHistoryDto>>();

                if (sales == null)
                {
                    MessageBox.Show("No data");
                    return new List<GetStockInHistoryDto>();
                }

                return sales;

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
                return new List<GetStockInHistoryDto>();
            }
        }
        private void OnRowNumber(object? sender, DataGridViewRowPostPaintEventArgs e)
        {
            var gridView = sender as DataGridView;
            if (gridView == null || e.RowIndex < 0) return;

            using (SolidBrush brush = new SolidBrush(gridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                string rowNumber = (e.RowIndex + 1).ToString();
                e.Graphics.DrawString(rowNumber, gridView.Font, brush, e.RowBounds.Left + 10, e.RowBounds.Top + 4);
            }
        }

    }
}

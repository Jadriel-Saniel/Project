﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.Application.Interfaces;
using Project.Domain.Entities;
using Project.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectDbContext _context;
        public ProductRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            try
            {
                var res = await _context.Products
                    .Include(p => p.Category)
                    .ToListAsync();

                return res;
            }
            catch (InvalidOperationException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 4060)
            {
                throw new InvalidOperationException("Database does not exist or access denied!", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while fetching categories.", ex);
            }
        }
        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id) ?? throw new KeyNotFoundException("Product name does not exist");

            return product;
            //return await _context.Products.FindAsync(id);
        }
        public async Task AddProductAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Duplicate product code detected!" + ex.Message);
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

             
        }
        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product), "Product name cannot be empty");
                }

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("The product cannot be updated because the name already exists. " + ex.Message);
            }
        }
        public async Task DeleteProductAsync(Guid id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to delete product: " + ex.Message);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{   
    //One to Many Relationships with Product
    public class Category
    {
        public Guid CategoryId { get; set; } = Guid.NewGuid();
        public string? CategoryName { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WlZ.Products.Api.Models.DTOs
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Idcategory { get; set; }
    }
}
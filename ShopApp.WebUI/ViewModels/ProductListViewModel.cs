﻿using ShopApp.Entity;
using System;
using System.Collections.Generic;

namespace ShopApp.WebUI.ViewModels
{
    public class ProductListViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Product> Products { get; set; }
    }

    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }
        public int TotalPages()
        {
            return  (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); // 10/3
        }
    }
}

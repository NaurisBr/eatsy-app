﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eatsy_app.ViewModel
{
    public class OrderDetailViewModel
    {
        //Adding OrderDetailId property
        public int OrderDetailId { get; set; }
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }



    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Core.Models
{
    public class OrderInfo : BaseEntity
    {
        public string CustomerOrderNo { get; set; }
        public string SystemOrderNo { get; set; }
        public string OutputAddress{ get; set; }
        public string ArrivalAddress { get; set; }
        public int Amount { get; set; }
        public string QuantityUnit { get; set; }
        public double Weight { get; set; }
        public string WeightUnit { get; set; }
        public string MaterialCode { get; set; }
        public string Material { get; set; }
        public string Note { get; set; }
        public int OrderStatu { get; set; }
    }
}

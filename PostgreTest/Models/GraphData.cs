﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PostgreTest.Models
{
    public class TradeData
    {
        public long Id { get; set; }

        public decimal Low { get; set; }

        public decimal High { get; set; }

        public decimal Open { get; set; }

        public decimal Close { get; set; }

        public decimal Volume { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Symbol { get; set; }

     
     
    }
}

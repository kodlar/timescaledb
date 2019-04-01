using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgreTest.Api.Models
{
    public class GraphData
    {
        public long Id { get; set; }

        public decimal Low { get; set; }

        public decimal High { get; set; }

        public decimal Open { get; set; }

        public decimal Close { get; set; }

        public decimal Volume { get; set; }

        public Int32 CreatedDate { get; set; }   
        [NotMapped]
        public string Symbol { get; set; }
    
        

    }
}

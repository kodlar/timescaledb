using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgreTest.Api.Models
{
    public class TradeViewResultModel
    {  
            public string s { get; set; }
            public List<long> t { get; set; }
            public List<decimal> h { get; set; }
            public List<decimal> o { get; set; }
            public List<decimal> l { get; set; }
            public List<decimal> c { get; set; }
            public List<decimal> v { get; set; }
        
    }
}

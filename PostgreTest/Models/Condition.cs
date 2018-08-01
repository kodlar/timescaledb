using System;
using System.Collections.Generic;
using System.Text;

namespace PostgreTest.Models
{
    public class Condition
    {
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace PostgreTest.Models
{
    public partial class DimensionSlice
    {
        public int Id { get; set; }
        public int DimensionId { get; set; }
        public long RangeStart { get; set; }
        public long RangeEnd { get; set; }

        public Dimension Dimension { get; set; }
    }
}

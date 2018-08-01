using System;
using System.Collections.Generic;

namespace PostgreTest.Models
{
    public partial class Dimension
    {
        public Dimension()
        {
            DimensionSlice = new HashSet<DimensionSlice>();
        }

        public int Id { get; set; }
        public int HypertableId { get; set; }
        public uint ColumnType { get; set; }
        public bool Aligned { get; set; }
        public short? NumSlices { get; set; }
        public long? IntervalLength { get; set; }

        public Hypertable Hypertable { get; set; }
        public ICollection<DimensionSlice> DimensionSlice { get; set; }
    }
}

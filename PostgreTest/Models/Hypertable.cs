using System;
using System.Collections.Generic;

namespace PostgreTest.Models
{
    public partial class Hypertable
    {
        public Hypertable()
        {
            Chunk = new HashSet<Chunk>();
            Dimension = new HashSet<Dimension>();
            Tablespace = new HashSet<Tablespace>();
        }

        public int Id { get; set; }
        public short NumDimensions { get; set; }

        public ICollection<Chunk> Chunk { get; set; }
        public ICollection<Dimension> Dimension { get; set; }
        public ICollection<Tablespace> Tablespace { get; set; }
    }
}

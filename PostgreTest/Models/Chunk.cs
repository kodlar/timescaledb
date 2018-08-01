using System;
using System.Collections.Generic;

namespace PostgreTest.Models
{
    public partial class Chunk
    {
        public int Id { get; set; }
        public int HypertableId { get; set; }

        public Hypertable Hypertable { get; set; }
    }
}

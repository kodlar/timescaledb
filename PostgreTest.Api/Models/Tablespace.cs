namespace PostgreTest.Api.Models
{
    public partial class Tablespace
    {
        public int Id { get; set; }
        public int HypertableId { get; set; }

        public Hypertable Hypertable { get; set; }
    }
}

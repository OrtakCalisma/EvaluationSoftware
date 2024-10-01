using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int PartNumber { get; set; }
        public string SerialNumber { get; set; }
        public ProductTypes Type { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserManuel { get; set; }
        public DateTime EntryDate { get; set; }
        public string ITAId { get; set; }
        public string HardwareRevision { get; set; }

    }
}

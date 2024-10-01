using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TPS
    {
        public int Id { get; set; }
        public int PartNumber { get; set; }
        public int UUTPartNumber { get; set; }
        public int VersionNumber { get; set; }
        public int FirmwareVersionNumber { get; set; }
    }
}

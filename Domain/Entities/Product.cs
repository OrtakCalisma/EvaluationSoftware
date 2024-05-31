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
        public string SerialNumber { get; set; }

        public string Type { get; set; }
        public string ProjectName { get; set; }

    }
}

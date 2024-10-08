﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ATE
    {
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TPSId { get; set; }
        public DateTime CalibrationDate { get; set; }
        public string BomList { get; set; }
    }
}

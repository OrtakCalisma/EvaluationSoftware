﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ITA
    {
        public int Id { get; set; }
        public int PartNumber { get; set; }
        public string BomList { get; set; }
        public string Wiring_2D { get; set; }
        public int ATEId { get; set; }
        public int TPSId { get; set; }
        public string Name { get; set; }

    }
}

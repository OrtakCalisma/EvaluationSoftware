﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HRS
    {
        public int Id { get; set; }
        public string DoorsId { get; set; }
        public string Description { get; set; }
        public string MoC { get; set; }
        public string Version { get; set; }
    }
}

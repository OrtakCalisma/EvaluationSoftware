﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Faults
    {
        public int Id { get; set; }
        public string ProductSerialNumber { get; set; }
        public string Explanation { get; set; }
        public string Suggestion { get; set; }
        public DateTime Date { get; set; }
        public bool IsSolved { get; set; }
    }
}

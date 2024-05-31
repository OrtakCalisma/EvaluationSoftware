using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Faults
    {
        public int Id { get; set; }
        public Test TestId { get; set; }
        public string Explanation { get; set; }
        public bool IsOpen { get; set; }
        public string SolvingExplation { get; set; }
    }
}

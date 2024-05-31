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
        public Product ProductId { get; set; }
        public string Explanation { get; set; }
        public DateTime FaultDate { get; set; }
        public bool IsSolved { get; set; }
        public string SolvingExplation { get; set; }
        public DateTime SolvingDate { get; set; }
    }
}

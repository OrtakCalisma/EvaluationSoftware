using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Solvings
    {
        public int Id { get; set; }
        public virtual int FaultId { get; set; }
        public string SolvingExplanation { get; set; }
        public DateTime? SolvingDate { get; set; }
        public string SolvingUser { get; set; }
    }
}

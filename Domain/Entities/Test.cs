using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string ProductSerialNumber  { get; set; }
        public string TestUser { get; set; }
        public TestStates State { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
    }
}

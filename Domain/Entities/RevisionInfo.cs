using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RevisionInfo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UUTHwRev { get; set; }
        public int V27RevNumber { get; set; }
        public int TPSId { get; set; }
        public int ATEId { get; set; }
        public int ITAId { get; set; }
    }
}

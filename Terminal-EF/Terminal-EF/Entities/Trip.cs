using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_EF.Entities
{
   public class Trip
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal TicketPrice { get; set; }
        public Bus Bus { get; set; }
        public int GroupId { get; set; }
        public decimal  Total { get; set; }
    }
}

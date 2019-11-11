using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDemo.Data.Entities
{
    public class CompanyMargin
    {
        public int Id { get; set; }
        public decimal Margin { get; set; }
        public Train Train { get; set; }
    }
}

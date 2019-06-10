using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Base
{
    public class Loan
    {
        //public int accountId { get; set; }
        //public int loanId { get; set; }
        //public DateTime start { get; set; }
        //public DateTime end { get; set; }
        public decimal principal { get; set; }
        public int numberOfPayments { get; set; }
        public decimal apr { get; set; }
    }
}

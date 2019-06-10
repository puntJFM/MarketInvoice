using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Base
{
    public class Installment
    {
        public int installmentNumber { get; set; }
        public decimal amountDue { get; set; }
        public decimal principal { get; set; }
        public decimal interest { get; set; }
        public int numberOfPayments { get; set; }
    }
}

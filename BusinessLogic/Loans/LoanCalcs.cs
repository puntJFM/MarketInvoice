using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Base;

namespace BusinessLogic.Loans
{
    public class LoanCalcs
    {


        public static decimal CalculatePayment(decimal loanAmount, decimal apr, int numberOfPayments)
        {
            var rate = (apr / 100) / numberOfPayments;
            decimal payment = Convert.ToDecimal((Convert.ToDouble(rate * loanAmount)) / ( 1 - Math.Pow(1 + Convert.ToDouble(rate) , numberOfPayments * -1)));

            return Math.Round(payment, 2);
        }


    }
}

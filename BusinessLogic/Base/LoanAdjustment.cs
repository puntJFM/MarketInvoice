using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Base
{
    public class LoanAdjustment
    {

        public decimal totalToPay { get; set; }
        public decimal totalInterest { get; set; }
        public decimal loanInstallment { get; set; }
        public decimal interestInstallment { get; set; }
        public decimal loanAdjustment { get; set; }
        public decimal interestAdjustment { get; set; }
        public decimal adjustedLoanAmount { get; set; }       
        public decimal adjustedInterestAmount { get; set; }
        


        public static LoanAdjustment GetLoanAdjustment(decimal loanAmount, decimal numberOfPayments, decimal payment)
        {
            var la = new LoanAdjustment();

            la.totalToPay = Math.Round((payment * numberOfPayments), 2);
            la.totalInterest = Math.Round(la.totalToPay - loanAmount, 2);

            /* Do adjustments to cater for rounding 'errors' 
                Typically the first payment on any loan/DD schedule is slightly different to future payments
             */
            la.loanInstallment = Math.Round((decimal)loanAmount / (decimal)numberOfPayments, 2);
            la.loanAdjustment = loanAmount - (la.loanInstallment * numberOfPayments);

            la.interestInstallment = Math.Round(la.totalInterest / numberOfPayments, 2);
            la.interestAdjustment = (loanAmount + (la.interestInstallment * numberOfPayments)) - la.totalToPay;

            la.adjustedLoanAmount = la.totalToPay - la.loanAdjustment;
            la.adjustedInterestAmount = la.totalInterest - la.interestAdjustment;

            return la;
        }

    }
}

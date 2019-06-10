using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Base
{
    public class LoanSummary
    {
        //public int accountId { get; set; }
        public decimal weeklyRepayment { get; set; }
        public decimal totalRepaid { get; set; }
        public decimal totalInterest { get; set; }


        public static LoanSummary GetLoanSummary(decimal loanAmount, decimal apr, int numberOfPayments)
        {
            //get periodical payment amount
            decimal payment = Math.Round(Loans.LoanCalcs.CalculatePayment(loanAmount, apr, numberOfPayments), 2);

            var loanAdjustments = LoanAdjustment.GetLoanAdjustment(loanAmount, numberOfPayments, payment);

            var ls = new LoanSummary(){ weeklyRepayment = payment, totalRepaid = loanAdjustments.totalToPay, totalInterest = loanAdjustments.totalInterest };

            return ls;

        }

    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Base
{
    public class LoanRepaymentSchedule
    {
        //Can add in unique identifer as required
        //public int accountId { get; set; }
        public List<Installment> installments;
        public LoanRepaymentSchedule()
        {
            //initialise list here
            installments = new List<Installment>();
        }

        public static LoanRepaymentSchedule GetRepaymentSchedule(decimal loanAmount, decimal apr, int numberOfPayments)
        {
            var lrs = new LoanRepaymentSchedule();

            //get periodical payment amount
            decimal payment = Math.Round(Loans.LoanCalcs.CalculatePayment(loanAmount, apr, numberOfPayments), 2);

            ///* Do adjustments to cater for rounding 'errors' 
            //    Typically the first payment on any loan/DD schedule is slightly different to future payments
            // */
            var loanAdjustments = LoanAdjustment.GetLoanAdjustment(loanAmount, numberOfPayments, payment);


            decimal principalStillToPay = loanAdjustments.loanInstallment * numberOfPayments;
            for (int i = 1; i <= numberOfPayments; i++)
            {
                if (i == 1)
                {
                    loanAdjustments.interestInstallment -= loanAdjustments.interestAdjustment;
                    principalStillToPay += loanAdjustments.loanAdjustment;
                }
                lrs.installments.Add(new Installment
                {
                    installmentNumber = i,
                    amountDue = loanAdjustments.totalToPay,
                    principal = principalStillToPay,
                    interest = loanAdjustments.interestInstallment
                });

                loanAdjustments.totalToPay -= payment;
                principalStillToPay -= loanAdjustments.loanInstallment;
            }

            return lrs;
        }

    }
}

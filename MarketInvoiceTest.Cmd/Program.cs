using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizLogic = BusinessLogic.Loans;
using BizBase = BusinessLogic.Base;
using System.Web.Script.Serialization;

namespace MarketInvoiceTest.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            TestLoanRespaymentCalc();
        }

        private static void TestLoanRespaymentCalc()
        {

            decimal payment1 = BizLogic.LoanCalcs.CalculatePayment(9500.00M, 7.5M, 52);

            var lrs = new BizBase.LoanRepaymentSchedule();

            var loanAmount = 50000;

            int numberOfPayments = 52;
            int installmentCount = 0;
            decimal payment = Math.Round(BizLogic.LoanCalcs.CalculatePayment(loanAmount, 19M, numberOfPayments), 2);
          
            var totalToPay =  Math.Round( (payment * numberOfPayments), 2);
            var totalInterest = Math.Round(totalToPay - loanAmount, 2);

            var interestInstallment = Math.Round(totalInterest / numberOfPayments, 2);
            decimal loanInstallment = Math.Round((decimal)loanAmount / (decimal)numberOfPayments, 2);

            decimal principal = loanAmount;

            var interestPaymentAdjustment = totalInterest - (interestInstallment * numberOfPayments);
            var prinicpalPaymentAdjustment = loanAmount - (loanInstallment * numberOfPayments);

            for (int i = 1; i <= 52; i++)
            {
                installmentCount++;

                if (i==1)
                    Console.WriteLine("installmentNumber " + i + "amountDue " + totalToPay + "principal " + principal + "interest " + (interestInstallment + interestPaymentAdjustment));
                else
                    Console.WriteLine("installmentNumber " + i + "amountDue " + totalToPay + "principal " + principal + "interest " + interestInstallment);

                totalToPay -= payment;
                principal -= loanInstallment;
                //totalInterest -= interestInstallment;

                lrs.installments.Add(new BizBase.Installment
                {
                    installmentNumber = i,
                    amountDue = totalToPay
                    ,
                    interest = interestInstallment,
                    principal = principal
                });

            }

        //    var json = new JavaScriptSerializer().Serialize(lrs.installments);

            //foreach (var item in lrs.installments)
            //{
            //    Console.WriteLine(item.installmentNumber + " | " + item.amountDue + "|" + "|" + item.numberOfPayments);

            //    var json = new JavaScriptSerializer().Serialize(lrs.installments);
            //}
            Console.ReadLine();

        }

    }
}

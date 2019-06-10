# MarketInvoice


Typical calls:

http://localhost:56963/api/loansummary?amount=50000&apr=19

http://localhost:56963/api/RepaymentSchedule?amount=50000&apr=19


- Loan calculations in a separate project (BusinessLogic) as you would want one central library of calculations for the whole organisation.

- Simple input validation on the LoanSummary inputs [Route("api/LoanSummary")] - looks for apr between [Range(0, 999)] and loan amount between [Range(0, 100000000)]
Values stored in LoanSummaryInput (part of BusinessLogic project)

- After the periodic payment has been calculated there is a call to a LoanAdjustment class. Typically the sum of the periodic payments will be a few pence out from (total interest + total principal)

- I typically add a command line project (MarketInvoiceTest.Cmd) to allow easy testing without running up a browser.

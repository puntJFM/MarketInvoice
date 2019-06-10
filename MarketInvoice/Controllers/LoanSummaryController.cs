using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BizLogic = BusinessLogic.Loans;
using BizBase = BusinessLogic.Base;
using System.Web.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using System.Web.Script.Serialization;

namespace MarketInvoice.Controllers
{
    public class LoanSummaryController : ApiController
    {
        [Route("api/LoanSummary")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] BizBase.LoanSummaryInput lsi)
        {

            if (ModelState.IsValid)
            {
                var lrs = BizBase.LoanSummary.GetLoanSummary(lsi.amount, lsi.apr, 52);
                var json = new JavaScriptSerializer().Serialize(lrs);
                return Json(json);
            }
            else
            {
                var message = String.Format("Invalid inputs: {0} {1} ", lsi.amount, lsi.apr);
                return BadRequest(message);
            }
        }

        //public IHttpActionResult Get(decimal amount, decimal apr)
        //{
        //    /*TO DO add check for valid values*/
        //    var lsi = new BizBase.LoanSummaryInput();
        //    lsi.amount = amount;
        //    lsi.apr = apr;

        //    var lrs = BizBase.LoanSummary.GetLoanSummary(amount, apr, 52);
        //    var json = new JavaScriptSerializer().Serialize(lrs);

        //    return Json(json);
        //}

        // GET: api/LoanSummary
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET: api/LoanSummary/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/LoanSummary
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LoanSummary/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LoanSummary/5
        public void Delete(int id)
        {
        }

    }
}

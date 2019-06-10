using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using BizBase = BusinessLogic.Base;

namespace MarketInvoice.Controllers
{
    public class RepaymentScheduleController : ApiController
    {
        public IHttpActionResult Get(decimal amount, decimal apr)
        {
            /*TO DO add check for valid values*/
            /*TO DO get period (weekly,monthly, etc) and period value as inputs */
            var lrs = BizBase.LoanRepaymentSchedule.GetRepaymentSchedule(amount, apr, 52);
            var json = new JavaScriptSerializer().Serialize(lrs);

            return Json(json);
        }




        // GET: api/RepaymentSchedule
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RepaymentSchedule/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RepaymentSchedule
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RepaymentSchedule/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RepaymentSchedule/5
        public void Delete(int id)
        {
        }
    }
}

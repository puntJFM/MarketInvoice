using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;
using System.Net.Http;


namespace BusinessLogic.Base
{
    public class LoanSummaryInput
    {
        [Required]
        [Range(0, 100000000)]
        public decimal amount { get; set; }
        [Range(0, 999)]
        public decimal apr { get; set; }
    }


}

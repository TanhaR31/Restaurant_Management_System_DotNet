using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BEL;
using BLL;
using TierApp.Auth;

namespace TierApp.Controllers
{
    [EnableCors("*", "*", "*")]
    //[CustomAuth]
    public class SalaryController : ApiController
    {
        [Route("api/salary/alldeliveryman")]
        [HttpGet]
        public HttpResponseMessage GetDeliveryman()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DeliveryDeliverymanService.GetAllDeliveryman());
        }

        [Route("api/salary/allsalary")]
        [HttpGet]
        public HttpResponseMessage GetSalary()
        {
            return Request.CreateResponse(HttpStatusCode.OK, SalaryService.GetSalary());
        }

        [Route("api/salary/give")]
        [HttpPost]
        public HttpResponseMessage GiveSalary(SalaryModel sal)
        {
            SalaryService.GiveSalary(sal);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

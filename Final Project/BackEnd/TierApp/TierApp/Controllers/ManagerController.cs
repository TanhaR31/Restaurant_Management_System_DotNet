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
    public class ManagerController : ApiController
    {
        [Route("api/manager/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(ManagerModel man)
        {
            ManagerService.Edit(man);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/manager/info")]
        [HttpGet]
        public HttpResponseMessage GetInfo()
        {
            return Request.CreateResponse(HttpStatusCode.OK, ManagerService.Getinfo());
        }
    }
}

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
    public class FeedbackController : ApiController
    {
        [Route("api/feedback/all")]
        [HttpGet]
        public HttpResponseMessage GetAllFeedback()
        {
            return Request.CreateResponse(HttpStatusCode.OK, FeedbackService.GetAllFeedback());
        }
    }
}

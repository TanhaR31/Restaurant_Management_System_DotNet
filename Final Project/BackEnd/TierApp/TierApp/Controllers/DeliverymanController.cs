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
    public class DeliverymanController : ApiController
    {
        [Route("api/deliveryman/all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DeliverymanService.Get());
        }
        [Route("api/deliveryman/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, DeliverymanService.Get(id));
        }
        [Route("api/deliveryman/create")]
        [HttpPost]
        public HttpResponseMessage Create(DeliverymanModel user)
        {
            DeliverymanService.Create(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [Route("api/deliveryman/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(DeliverymanModel user)
        {
            DeliverymanService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [Route("api/deliveryman/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            DeliverymanService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

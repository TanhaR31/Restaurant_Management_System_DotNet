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
    public class DeliveryDeliverymanController : ApiController
    {
        [Route("api/deliverydeliveryman/alldeliveries")]
        [HttpGet]
        public HttpResponseMessage GetDeliveries()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DeliveryDeliverymanService.GetAllDeliveries());
        }

        [Route("api/deliverydeliveryman/alldeliveryman")]
        [HttpGet]
        public HttpResponseMessage GetDeliveryman()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DeliveryDeliverymanService.GetAllDeliveryman());
        }

        [Route("api/deliverydeliveryman/allorders")]
        [HttpGet]
        public HttpResponseMessage GetOrder()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DeliveryDeliverymanService.GetAllOrder());
        }

        [Route("api/deliverydeliveryman/freedeliveryman")]
        [HttpGet]
        public HttpResponseMessage GetFreeDeliveryman()
        {
            return Request.CreateResponse(HttpStatusCode.OK, DeliveryDeliverymanService.GetFreeDeliveryman());
        }

        [Route("api/deliverydeliveryman/assigndeliveryman")]
        [HttpPost]
        public HttpResponseMessage Edit(DeliveryModel del)
        {
            DeliveryDeliverymanService.Assign(del);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

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
    public class InventoryController : ApiController
    {
        [Route("api/inventory/allproduct")]
        [HttpGet]
        public HttpResponseMessage GetAllInventoryProduct()
        {
            return Request.CreateResponse(HttpStatusCode.OK, InventoryService.GetAllInventoryProduct());
        }

        [Route("api/inventory/allorder")]
        [HttpGet]
        public HttpResponseMessage GetAllInventoryOrder()
        {
            return Request.CreateResponse(HttpStatusCode.OK, InventoryService.GetAllInventoryOrder());
        }

        [Route("api/inventory/alltotal")]
        [HttpGet]
        public HttpResponseMessage GetAllInventoryTotal()
        {
            return Request.CreateResponse(HttpStatusCode.OK, InventoryService.GetAllInventoryTotal());
        }

        [Route("api/inventory/ordercreate")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(InvProductDetailModel det)
        {
            InventoryService.CreateOrder(det);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/inventory/orderplace")]
        [HttpGet]
        public HttpResponseMessage GetPlaceOrder()
        {
            return Request.CreateResponse(HttpStatusCode.OK, InventoryService.PlaceOrder());
        }

        [Route("api/inventory/orderrecieved")]
        [HttpPost]
        public HttpResponseMessage RecieveOrder(InvOrderTotalModel ot)
        {
            InventoryService.RecieveOrder(ot);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

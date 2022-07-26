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
    [EnableCors("*","*","*")]
    [CustomAuth]
    public class UserController : ApiController
    {
        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.Get());
        }
        [Route("api/users/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.Get(id));
        }
        [Route("api/users/create")]
        [HttpPost]
        public HttpResponseMessage Create(UserModel user)
        {
            UserService.Create(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [Route("api/users/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(UserModel user)
        {
            UserService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [Route("api/users/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

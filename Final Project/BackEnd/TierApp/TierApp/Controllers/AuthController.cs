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
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Auth(UserModel user)
        { 
            var data = AuthService.Auth(user);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
        }

        [Route("api/logout")]
        [HttpPost]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            if (token != null)
            {
                var rs = AuthService.Logout(token);
                if (rs)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfull Logout");
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid token to logout");
        }
    }
}

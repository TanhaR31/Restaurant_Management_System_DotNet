using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TierApp.Auth
{
    public class CustomAuth : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound, "No Token Found !!");

            }
            else
            {
                string token = authHeader.ToString();
                var rs = AuthService.CheckValidityToken(token);
                if (!rs)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized Access !!");
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}
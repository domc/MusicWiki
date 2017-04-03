using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace MusicWikiAPI
{
    public class MyExceptionAttribute:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //Prepare msg response for exceptions
            HttpResponseMessage msgResp = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            msgResp.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = msgResp;
            base.OnException(actionExecutedContext);
        }
    }
}
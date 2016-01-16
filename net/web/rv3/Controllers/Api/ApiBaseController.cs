using DTS.Helpers.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace rv3.Controllers.Api
{
    public class ApiBaseController : ApiController
    {
        /// <summary>
        /// Logger that can be accessed by derived classes
        /// </summary>
        protected INLogger Logger { get; set; }

        public ApiBaseController() { }

        public ApiBaseController(INLogger logger)
        {
            Logger = logger;
        }

        protected HttpResponseMessage CreateHttpResponseMessage(HttpStatusCode httpStatusCode, string content, string reasonPhrase)
        {
            return
                new HttpResponseMessage(httpStatusCode)
                {
                    Content = new StringContent(content),
                    ReasonPhrase = reasonPhrase
                };
        }
    }
}

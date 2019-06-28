using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class DemoController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "嗝"};
        }
    }
}

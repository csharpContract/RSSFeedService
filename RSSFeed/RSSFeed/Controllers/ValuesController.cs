using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Web.Http;
using System.Xml;
using static RSSFeed.RSSFeed;

using System.Web.Http.Filters;

public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        if (actionExecutedContext.Response != null)
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

        base.OnActionExecuted(actionExecutedContext);
    }
}

namespace RSSFeed.Controllers
{
    [AllowCrossSiteJson]
    public class ValuesController : ApiController
    {
        public object FeedReader { get; private set; }

        [HttpGet]
        public IEnumerable<PressRSS> Index()
        {
           return  RSSFeed.GetFeed();
        }

      
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

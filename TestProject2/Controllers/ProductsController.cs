using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestProject2.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
      [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
      public enum Widgets
      {
        Bolt,

        Screw,

        Nut,

        Motor
      };

      [HttpGet, Route("widget/{widget:enum(TestProject2.Controllers.ProductsController+Widgets)}")]
      public string GetProductsWithWidget(Widgets widget)
      {
        return "widget-" + widget.ToString();
      }


        // GET: api/Products
        [HttpGet, Route("")]
        [Route("~/prods")] // ~ Overrides route prefix attribute

        //OR
        //[Route("")]
        //[AcceptVerbs("GET", "CUSTOMVERB")]
        public IEnumerable<string> GetAllProducts()
        {
            return new string[] { "product1", "product2" };
        }

        // GET: api/Products/5
        [HttpGet, Route("{id:int:range(1000,3000)}", Name = "GetById")]
        public string Get(int id)
        {
            return "product" + id;
        }

        // GET: api/Products/5/orders/custid
        [HttpGet, Route("{id}/orders/{custId}")]
        public string Get(int id, string custId)
        {
          return "productForCust";
        }

        // POST: api/Products
        [HttpPost, Route("")]
        public void CreateProduct([FromBody]string value)
        {
        }

        // POST: api/Products
        [HttpPost, Route("{prodId:int:range(1000, 3000)}")]
        public HttpResponseMessage CreateProduct([FromUri]int prodId)
        {
          var response = this.Request.CreateResponse(HttpStatusCode.Created);
          var uri = this.Url.Link("GetById", new { id = prodId });
          response.Headers.Location = new Uri(uri);
          return response;
        }

        // PUT: api/Products/5
        [HttpPut, Route("{id:int:range(1000,3000)}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        [HttpDelete, Route("{id:int:range(1000,3000)}")]
        public void Delete(int id)
        {
        }
    }
}

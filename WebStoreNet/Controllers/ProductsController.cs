using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using WebStoreDataAcess;

namespace WebStoreNet.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class ProductsController : ApiController
    {
        public IEnumerable<Product> Get()
        {
            using (WebStoreEntities entities = new WebStoreEntities())
            {
                return entities.Products.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (WebStoreEntities entities = new WebStoreEntities())
            {
                var entity = entities.Products.FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with id = " + id.ToString() + " not found");
                }
            }
        }

        public HttpResponseMessage Post([FromBody] Product product)
        {
            try
            {
                using (WebStoreEntities entities = new WebStoreEntities())
                {
                    entities.Products.Add(product);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, product);
                    message.Headers.Location = new Uri(Request.RequestUri + product.Id.ToString());
                    return message;

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (WebStoreEntities entities = new WebStoreEntities())
                {
                    var entity = entities.Products.FirstOrDefault(e => e.Id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.Products.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody]Product product)
        {
            try
            {
                using (WebStoreEntities entities = new WebStoreEntities())
                {
                    var entity = entities.Products.FirstOrDefault(e => e.Id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with id = " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.Name = product.Name;
                        entity.Description = product.Description;
                        entity.Stock = product.Stock;
                        entity.CategoryId = product.CategoryId;

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
    }


}

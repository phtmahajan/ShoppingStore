using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductStore.Interface;
using ProductStore.Models;
using ProductStore.Repository;


namespace ProductStore.Controllers
{
    public class ProductsController : ApiController
    {
      

        // Project products to product DTOs.
        private readonly IProductRepository repository = new ProductRepository();

        public IEnumerable<ProductDTO> GetProducts()
        {
            return repository.MapProducts().AsEnumerable();
        }

        public ProductDTO GetProduct(int id)
        {
            var product = repository.GetProduct(id);
            if (product == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return product;
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}

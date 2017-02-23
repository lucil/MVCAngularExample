using System.Web.Mvc;
using Cobisi.Web.MvcExtensions;
using EURIS.Service;
using EURIS.Service.ViewModels;
using EURISTest.Results;

namespace EURISTest.Controllers
{
    public class ProductController : Controller
    {
        [Route("~/api/products")]
        [HttpGet]
        public JsonNetResult Index()
        {
            var prod = new ProductService();
            var products = prod.GetProducts();

            return new JsonNetResult
            {
                Data = products
            };
        }

        [Route("~/api/products/verify")]
        [HttpGet]
        public JsonNetResult ProductExists(string productCode)
        {
            var prod = new ProductService();
            var productExists = prod.ProductAlreadyExists(productCode);
            return new JsonNetResult
            {
                Data = productExists
            };
        }

        [Route("~/api/products")]
        [HttpGet]
        public JsonNetResult GetProduct([RoutePart]int productId)
        {
            var prod = new ProductService();
            var product = prod.GetProduct(productId);
            return new JsonNetResult
            {
                Data = product
            };
        }

        [Route("~/api/products/create")]
        [HttpPost]
        public JsonNetResult CreateProduct(ProductViewModel product)
        {
            var prod = new ProductService();
            var newProduct = prod.CreateProduct(product);

            return new JsonNetResult
            {
                Data = newProduct
            };
        }

        [Route("~/api/products/edit")]
        [HttpPost]
        public JsonNetResult EditProduct(ProductViewModel product)
        {
            var prod = new ProductService();
            var productEdit = prod.EditProduct(product);

            return new JsonNetResult
            {
                Data = productEdit
            };
        }

        [Route("~/api/products/delete")]
        [HttpPost]
        public JsonNetResult DeleteProduct(int productId)
        {
            var prod = new ProductService();
            prod.DeleteProduct(productId);

            return new JsonNetResult
            {
                Data = new { productId = productId }
            };
        }

    }
}

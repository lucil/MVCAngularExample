using System.Web.Mvc;
using Cobisi.Web.MvcExtensions;
using EURIS.Service;
using EURIS.Service.ViewModels;
using EURISTest.Results;

namespace EURISTest.Controllers
{
    public class PriceListController : Controller
    {
        [Route("~/api/pricelists")]
        [HttpGet]
        public JsonNetResult Index()
        {
            var priceListService = new PriceListService();
            var priceLists = priceListService.GetPriceLists();

            return new JsonNetResult
            {
                Data = priceLists
            };
        }

        [Route("~/api/pricelists/verify")]
        [HttpGet]
        public JsonNetResult PriceListExists(string priceListCode)
        {
            var prod = new PriceListService();
            var priceListExists = prod.PriceListAlreadyExists(priceListCode);
            return new JsonNetResult
            {
                Data = priceListExists
            };
        }

        [Route("~/api/pricelists")]
        [HttpGet]
        public JsonNetResult GetPriceList([RoutePart]int priceListId)
        {
            var prod = new PriceListService();
            var priceList = prod.GetPriceList(priceListId);
            return new JsonNetResult
            {
                Data = priceList
            };
        }

        [Route("~/api/pricelists/create")]
        [HttpPost]
        public JsonNetResult CreatePriceList(PriceListViewModel priceList)
        {
            var prod = new PriceListService();
            var newPriceList = prod.CreatePriceList(priceList);

            return new JsonNetResult
            {
                Data = newPriceList
            };
        }

        [Route("~/api/pricelists/edit")]
        [HttpPost]
        public JsonNetResult EditPriceList(PriceListViewModel priceList)
        {
            var prod = new PriceListService();
            var priceListEdit = prod.EditPriceList(priceList);

            return new JsonNetResult
            {
                Data = priceListEdit
            };
        }
        
        [Route("~/api/pricelists/delete")]
        [HttpPost]
        public JsonNetResult DeletePricelist(int priceListId)
        {
            var priceList = new PriceListService();
            priceList.DeletePriceList(priceListId);

            return new JsonNetResult
            {
                Data = new { priceListId = priceListId }
            };
        }

        [Route("~/api/pricelists/products")]
        [HttpGet]
        public JsonNetResult GetProducts([RoutePart]int priceListId)
        {
            var priceListService = new PriceListService();
            var products = priceListService.GetProducts(priceListId);

            return new JsonNetResult
            {
                Data = products
            };
        }

    }
}
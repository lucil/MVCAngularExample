using System.Collections.Generic;
using System.Linq;
using EURIS.Entities;
using EURIS.Service.ViewModels;

namespace EURIS.Service
{
    public class PriceListService
    {
        readonly EurisEntities _context = new EurisEntities();

        public List<PriceListViewModel> GetPriceLists()
        {
            var priceListData = (from item in _context.PriceList
                               select item).ToList();

            return priceListData.Select(p => new PriceListViewModel
            {
                PriceListId = p.PriceListId,
                PriceListCode = p.PriceListCode,
                Description = p.Description,
                NumberOfProducts = p.Product.Count,
                ContainsProducts = p.Product.Count > 0
            }).ToList();
        }

        public void DeletePriceList(int priceListId)
        {
            var priceList = new PriceList { PriceListId = priceListId };
            _context.PriceList.Attach(priceList);
            _context.PriceList.Remove(priceList);
            _context.SaveChanges();
        }

        public int CreatePriceList(PriceListViewModel priceListViewModel)
        {
            var priceList = new PriceList
            {
                PriceListCode = priceListViewModel.PriceListCode,
                Description = priceListViewModel.Description
            };

            //creo i prodotti da salvare
            if (priceListViewModel.ProductIds != null)
            {
                foreach (var productId in priceListViewModel.ProductIds)
                {
                    var product = _context.Product.FirstOrDefault(p => p.ProductId == productId);
                    priceList.Product.Add(product);
                }
            }

            var pr = _context.PriceList.Add(priceList);

            _context.SaveChanges();

            return pr.PriceListId;
        }

        public bool PriceListAlreadyExists(string priceListCode)
        {
            var item = _context.PriceList.FirstOrDefault(p => p.PriceListCode == priceListCode);
            return item != null;
        }

        public PriceListViewModel GetPriceList(int priceListId)
        {
            var item = _context.PriceList.First(p => p.PriceListId == priceListId);
            return new PriceListViewModel
            {
                PriceListId = item.PriceListId,
                PriceListCode = item.PriceListCode,
                ContainsProducts = item.Product.Count > 0,
                Description = item.Description,
                ProductIds = item.Product.Count > 0 ? item.Product.Select(x => x.ProductId) : new List<int>()
            };
        }

        public PriceListViewModel EditPriceList(PriceListViewModel priceListViewModel)
        {
            var pr = _context.PriceList.Include("Product").Single(u => u.PriceListId == priceListViewModel.PriceListId);

            pr.Product.Clear();
            if (priceListViewModel.ProductIds != null && priceListViewModel.ProductIds.Any())
            {
                var newProducts = _context.Product
                .Where(p => priceListViewModel.ProductIds.Contains(p.ProductId))
                .ToList();

                foreach (var newProduct in newProducts)
                {
                    pr.Product.Add(newProduct);
                }
            }
            
            var entry = _context.Entry(pr);
            pr.Description = priceListViewModel.Description;
            entry.Property(e => e.Description).IsModified = true;
            _context.SaveChanges();

            return GetPriceList(pr.PriceListId);
        }

        public IEnumerable<ProductViewModel> GetProducts(int priceListId)
        {
            var item = _context.PriceList.Include("Product").First(p => p.PriceListId == priceListId);
            var productData = item.Product;
            var products = new List<ProductViewModel>();
            if (productData.Any())
            {
                products.AddRange(productData.Select(pr => new ProductViewModel
                {
                    ProductId = pr.ProductId,
                    ProductCode = pr.ProductCode,
                    Description = pr.Description
                }));
            }
            return products;
        } 
    }
}

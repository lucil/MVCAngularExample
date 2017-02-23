using System.Collections.Generic;
using System.Linq;
using EURIS.Entities;
using EURIS.Service.ViewModels;

namespace EURIS.Service
{
    public class ProductService
    {
        readonly EurisEntities _context = new EurisEntities();

        public List<ProductViewModel> GetProducts()
        {
            var productData = (from item in _context.Product
                               select item).ToList();

            return productData.Select(product => new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductCode = product.ProductCode,
                Description = product.Description,
                IsContainedInPriceList = product.PriceList.Count > 0
            }).ToList();
        }

        public bool ProductAlreadyExists(string productCode)
        {
            var product = _context.Product.FirstOrDefault(p => p.ProductCode == productCode);
            return product != null;
        }

        public ProductViewModel GetProduct(int productId)
        {
            var product = _context.Product.First(p => p.ProductId == productId);
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductCode = product.ProductCode,
                IsContainedInPriceList = product.PriceList.Count > 0,
                Description = product.Description,
                PriceListIds = product.PriceList.Count > 0 ? product.PriceList.Select(x => x.PriceListId) : new List<int>()
            };
        }

        public int CreateProduct(ProductViewModel productViewModel)
        {
            var product = new Product
            {
                ProductCode = productViewModel.ProductCode,
                Description = productViewModel.Description
            };

            //creo i listini da salvare
            if (productViewModel.PriceListIds != null)
            {
                foreach (var priceListId in productViewModel.PriceListIds)
                {
                    var priceList = _context.PriceList.FirstOrDefault(p => p.PriceListId == priceListId);
                    product.PriceList.Add(priceList);
                }
            }

            var pr = _context.Product.Add(product);

            _context.SaveChanges();

            return pr.ProductId;
        }

        public void DeleteProduct(int productId)
        {
            var product = new Product { ProductId = productId };
            _context.Product.Attach(product);
            _context.Product.Remove(product);
            _context.SaveChanges();
        }

        public ProductViewModel EditProduct(ProductViewModel product)
        {
            var pr = _context.Product.Include("PriceList").Single(u => u.ProductId == product.ProductId);
            
            pr.PriceList.Clear();
            if (product.PriceListIds != null && product.PriceListIds.Any())
            {
                var newPriceLists = _context.PriceList
                .Where(r => product.PriceListIds.Contains(r.PriceListId))
                .ToList();
                
                foreach (var newPriceList in newPriceLists)
                {
                    pr.PriceList.Add(newPriceList);
                }

            }

            var entry = _context.Entry(pr);
            pr.Description = product.Description;
            entry.Property(e => e.Description).IsModified = true;
            _context.SaveChanges();

            return GetProduct(pr.ProductId);
        }
    }
}
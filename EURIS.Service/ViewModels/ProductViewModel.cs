using System.Collections.Generic;

namespace EURIS.Service.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> PriceListIds { get; set; }
        public bool IsContainedInPriceList { get; set; }
    }
}

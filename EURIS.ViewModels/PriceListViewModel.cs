using System.Collections.Generic;

namespace EURIS.ViewModels
{
    public class PriceListViewModel
    {
        public int PriceListId { get; set; }
        public string PriceListCode { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; } 
    }
}

using System.Collections.Generic;

namespace EURIS.Service.ViewModels
{
    public class PriceListViewModel
    {
        public int PriceListId { get; set; }
        public string PriceListCode { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> ProductIds { get; set; } 
        public int NumberOfProducts { get; set; }
        public bool ContainsProducts { get; set; }
    }
}

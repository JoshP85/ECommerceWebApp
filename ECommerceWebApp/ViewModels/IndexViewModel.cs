using ECommerceWebApp.Models;

namespace ECommerceWebApp.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ProductCategory> Categories { get; set; }
        public ICollection<string> CartItems { get; set; }
    }
}

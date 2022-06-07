using ClientManagementSys.Models;

namespace ClientManagementSys.ViewModel
{
    public class ProductlistVM
    {
        public ProductlistVM()
        {
            Product = new List<Product>();
        }
        public List<Product> Product { get; set; }
        public Organization organization { get; set; }
    }
}

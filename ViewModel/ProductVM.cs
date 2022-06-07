namespace ClientManagementSys.ViewModel
{
    public class ProductVM
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
       

        public int Product_Price { get; set; }
        public string Category { get; set; }
        public bool Product_Status { get; set; }
        public DateTime Product_CompleteDate { get; set; }
        //public IList<Product_VersionVM> product_v { get; set; }
    }
}

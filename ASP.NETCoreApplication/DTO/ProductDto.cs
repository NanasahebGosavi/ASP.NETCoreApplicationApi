using System.ComponentModel.DataAnnotations;


namespace ASP.NETCoreApplication.DTO
{
    public class ProductDto
    {
        [Required(ErrorMessage =" Product Name Is Required ")]
        public  string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductCategory { get; set; }
    }
}

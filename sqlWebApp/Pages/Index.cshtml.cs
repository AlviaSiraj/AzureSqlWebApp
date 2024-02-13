using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlWebApp.Models;
using sqlWebApp.Services;

namespace sqlWebApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> products;
        public void OnGet()
        {
            ProductService productService= new ProductService();
            products=productService.GetProducts();
        }
    }
}

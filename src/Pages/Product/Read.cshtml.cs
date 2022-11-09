namespace ContosoCrafts.WebSite.Pages.Product
{
    using System.Linq;

    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class ReadModel : PageModel
    {
        // Data middle tier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="productService">The service responsible for interacting with the data store.</param>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show
        public ProductModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id">The product id as a string.</param>
        public IActionResult OnGet(string id)
        {
            this.Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
            if (Product == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}

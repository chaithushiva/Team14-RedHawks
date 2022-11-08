namespace ContosoCrafts.WebSite.Pages.Product
{
    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Services;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    /// <summary>
    /// Create Page
    /// </summary>
    public class CreateModel : PageModel
    {
        // Data middle tier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService">The service responsible for interacting with the data store.</param>
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show
        public ProductModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <returns>Redirect the web page to the Update page populated with the data so the user can fill in the fields.</returns>
        public IActionResult OnGet()
        {
            Product = ProductService.CreateData();

            return RedirectToPage("./Update", new { Product.Id });
        }
    }
}

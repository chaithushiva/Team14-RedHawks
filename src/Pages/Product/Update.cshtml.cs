namespace ContosoCrafts.WebSite.Pages.Product
{
    using System.Linq;

    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Services;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    /// <summary>
    /// Manage the Update of the data for a single record.
    /// </summary>
    public class UpdateModel : PageModel
    {
        // Data middle tier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post.
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id">The article Id as a string.</param>
        public void OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Article
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns>IActionResult, redirect to the Index page.</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _ = ProductService.UpdateData(Product);

            return RedirectToPage("./Index");
        }
    }
}

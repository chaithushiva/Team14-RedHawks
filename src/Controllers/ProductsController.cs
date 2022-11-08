namespace ContosoCrafts.WebSite.Controllers
{
    using System.Collections.Generic;

    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Services;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Controller class for Articles
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }

        /// <summary>
        /// Add requested rating to article. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            _ = ProductService.AddRating(request.ProductId, request.Rating);

            return Ok();
        }
        /// <summary>
        /// Define a rating request class with article ID and rating. 
        /// </summary>
        public class RatingRequest
        {
            public string ProductId { get; set; }
            public int Rating { get; set; }
        }
    }
}
namespace ContosoCrafts.WebSite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class ProductModel
    {
        /// <summary>
        /// Define attributes of Product Model. 
        /// </summary>
        // Properties: Unique Identifier, Author(s),, URL, Image, SchoolName, Tags, Product Text/Body.

        // Unique identifier for the product
        public string Id { get; set; }

        // Author Name
        public string Author { get; set; }

        // A link to the image file to display in product preview
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // Web location for the product
        public string Url { get; set; }

        // Product schoolname
        [StringLength(maximumLength: 128, MinimumLength = 1, ErrorMessage = "The SchoolName should have a length of more than {2} and up to {1} characters")]
        public string SchoolName { get; set; }

        // Product SchoolAddress
        public string SchoolAddress { get; set; }

        // Product School Contact information
        public string SchoolContactInfo { get; set; }

        // Product School Email Id
        public string SchoolEmail { get; set; }

        // ratings for the product (remnant from Contoso Crafts site)
        public int[] Ratings { get; set; }

        // An enum to decription the product category (tag)
        public ProductTypeEnum ProductType { get; set; } = ProductTypeEnum.Undefined;

        // Store the Comments entered by the users on this product.
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        // To string method to display product as a text stirng
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}

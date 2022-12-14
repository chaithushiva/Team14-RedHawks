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
        [RegularExpression(@"^[a-zA-Z_\s-]{1,40}$", ErrorMessage = "Letters, spaces, and dashes only.")]
        public string Author { get; set; }

        // A link to the image file to display in product preview
        [JsonPropertyName("img")]
        [Url(ErrorMessage = "Invalid URL")]
        public string Image { get; set; }

        // Web location for the product
        [Required(ErrorMessage = "URL field is required.")]
        [Url(ErrorMessage = "Invalid URL")]
        public string Url { get; set; }

        // Product schoolname
        [RegularExpression(@"^(.*\S.*)$", ErrorMessage = "School name cannot be whitespace only.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sc field is required.")]
        [StringLength(maximumLength: 40, MinimumLength = 1, ErrorMessage = "The School Name should have a length of at least {2} and up to {1} characters")]
        public string SchoolName { get; set; }

        // Product SchoolAddress
        [Required(ErrorMessage = "Address field is required.")]
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
        [StringLength(maximumLength: 1024, MinimumLength = 1, ErrorMessage = "Comments must have a length of more than {2} and up to {1} characters")]
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        // To string method to display product as a text stirng
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}

namespace ContosoCrafts.WebSite.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using ContosoCrafts.WebSite.Models;
    using Microsoft.AspNetCore.Hosting;
    using static System.Net.Mime.MediaTypeNames;

    /// <summary>
    /// The JsonFileProductService class is responsible for interacting with the
    /// data store. The data store for this project is the products.json file.
    /// </summary>
    public class JsonFileProductService
    {
        private string defaultSchoolName = "Default School Name";
        private string defaultAddress = "School Address";
        private string defaultUrl = "Product URL";
        private string defaultImage = "No image specified";

        /// <summary>
        /// This is the default constructor.
        /// </summary>
        /// <param name="webHostEnvironment">Provides the information about the web hosting environment an application is running in.</param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Store the information about the web hosting environment an application is running in.
        /// </summary>
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// The full path of the json file, starting from the web root path.
        /// </summary>
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");

        /// <summary>
        /// Gets all the data from the json file and creates an instance of the ArticleModel.
        /// </summary>
        /// <returns>An Enumerable ArticleModel.</returns>
        public IEnumerable<ProductModel> GetAllData()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        /// <summary>
        /// Add Rating
        /// Take in the article ID and the rating
        /// If the rating does not exist, add it
        /// Save the update
        /// </summary>
        /// <param name="productId">The unique article Id number.</param>
        /// <param name="rating">The article rating integer value.</param>
        /// <returns>Returns true if ratings are added, otherwise return false.</returns>
        public bool AddRating(string productId, int rating)
        {
            // If the ArticleID is invalid, return
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            var products = GetAllData();

            // Look up the article, if it does not exist, return.
            var data = products.FirstOrDefault(x => x.Id.Equals(productId));
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundaries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundaries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exist, if there are none, 
            // then create the array.
            data.Ratings ??= new int[] { };

            // Add the Rating to the Array
            var ratings = data.Ratings.ToList();
            ratings.Add(rating);
            data.Ratings = ratings.ToArray();

            // Save the data back to the data store
            SaveData(products);

            return true;
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data">The ArticleModel.</param>
        public ProductModel UpdateData(ProductModel data)
        {
            var products = GetAllData();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                return null;
            }

            // Update the data to the new passed in values.
            productData.SchoolName = data.SchoolName;
            productData.SchoolAddress = data.SchoolAddress;
            productData.Url = data.Url;
            productData.Image = data.Image;
            productData.CommentList = data.CommentList;

            SaveData(products);

            return productData;
        }

        /// <summary>
        /// Save All articles data to storage.
        /// </summary>
        private void SaveData(IEnumerable<ProductModel> products)
        {
            using var outputStream = File.Create(JsonFileName);
            JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
                products
            );
        }

        /// <summary>
        /// Create a new article using default values.
        /// After create the user can update to set values.
        /// </summary>
        /// <returns>The ArticleModel.</returns>
        public ProductModel CreateProduct()
        {
            ProductModel product = new ProductModel()
            {
                Id = Guid.NewGuid().ToString(),
                SchoolName = defaultSchoolName,
                SchoolAddress = defaultAddress,
                Url = defaultUrl,
                Image = defaultImage,
            };

            // Get the current set, and append the new record to it because IEnumerable does not have Add.
            var dataSet = GetAllData();
            dataSet = dataSet.Append(product);

            SaveData(dataSet);

            return product;
        }

        /// <summary>
        /// Remove the item from the system.
        /// </summary>
        /// <returns>The ArticleModel.</returns>
        public ProductModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }
    }
}
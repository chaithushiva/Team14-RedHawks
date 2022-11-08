namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Define an enum for type Article. 
    /// </summary>
    public enum ProductTypeEnum
    {
        Undefined = 0,
        Laptops = 1,
        Projectors = 2,
        Desks = 3,
        SmartBoards = 4,
        NoteBooks = 6,
    }
    /// <summary>
    /// Define Article Type enum extensions. 
    /// </summary>
    public static class ProductTypeEnumExtensions
    {
        /// <summary>
        /// Display name of the Article type enum. 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DisplayName(this ProductTypeEnum data)
        {
            return data switch
            {
                ProductTypeEnum.Laptops => "Electronic Items",
                ProductTypeEnum.Projectors => "Electronic Items",
                ProductTypeEnum.Desks => "Stationery Items",
                ProductTypeEnum.SmartBoards => "Electronic Items",
                ProductTypeEnum.NoteBooks => "Stationery Items",

                // Default, Unknown
                _ => "",
            };
        }
    }
}
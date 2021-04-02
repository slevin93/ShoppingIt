namespace ShoppingIt.Crm.Core.Dto.Products
{
    /// <summary>
    /// Defines product details.
    /// </summary>
    public class ProductDetails
    {
        /// <summary>
        /// Gets or sets product id.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets price.
        /// </summary>
        public decimal SalesPrice { get; set; }

        /// <summary>
        /// Gets or sets the whole price.
        /// </summary>
        public decimal WholePrice { get; set; }

        /// <summary>
        /// Gets or sets is product is vattable.
        /// </summary>
        public bool IsVattable { get; set; }

        /// <summary>
        /// Gets or sets the stock.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets the whole sale link.
        /// </summary>
        public string WholeSaleLink { get; set; }

        /// <summary>
        /// Gets or sets the product picture.
        /// </summary>
        public string PictureLink { get; set; }

        /// <summary>
        /// Gets or sets if the product is active or not.
        /// </summary>
        public bool IsActive { get; set; }
    }
}

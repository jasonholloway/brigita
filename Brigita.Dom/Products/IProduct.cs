using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Products
{
    public interface IProduct : IEntity
    {

        /// <summary>
        /// Gets or sets the product type identifier
        /// </summary>
        int ProductTypeId { get; }
        /// <summary>
        /// Gets or sets the parent product identifier. It's used to identify associated products (only with "grouped" products)
        /// </summary>
        int ParentGroupedProductId { get; }
        /// <summary>
        /// Gets or sets the values indicating whether this product is visible in catalog or search results.
        /// It's used when this product is associated to some "grouped" one
        /// This way associated products could be accessed/added/etc only from a grouped product details page
        /// </summary>
        bool VisibleIndividually { get; }


        string Name { get; }
        string ShortDescription { get; }
        string FullDescription { get; }
        string AdminComment { get; }

        int ProductTemplateId { get; }
        int VendorId { get; }
        bool ShowOnHomePage { get; }

        string MetaKeywords { get; }
        string MetaDescription { get; }
        string MetaTitle { get; }

        bool AllowCustomerReviews { get; }
        int ApprovedRatingSum { get; }
        int NotApprovedRatingSum { get; }
        int ApprovedTotalReviews { get; }
        int NotApprovedTotalReviews { get; }

        bool SubjectToAcl { get;}
        bool LimitedToStores { get; }

        string Sku { get; }
        string ManufacturerPartNumber { get; }

        /// <summary>
        /// Gets or sets the Global Trade Item Number (GTIN). These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
        /// </summary>
         string Gtin { get; }

        bool IsGiftCard { get; }
        int GiftCardTypeId { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the product requires that other products are added to the cart (Product X requires Product Y)
        /// </summary>
         bool RequireOtherProducts { get; }
        /// <summary>
        /// Gets or sets a required product identifiers (comma separated)
        /// </summary>
         string RequiredProductIds { get; }
        /// <summary>
        /// Gets or sets a value indicating whether required products are automatically added to the cart
        /// </summary>
         bool AutomaticallyAddRequiredProducts { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is download
        /// </summary>
         bool IsDownload { get; }
        /// <summary>
        /// Gets or sets the download identifier
        /// </summary>
         int DownloadId { get; }
        /// <summary>
        /// Gets or sets a value indicating whether this downloadable product can be downloaded unlimited number of times
        /// </summary>
         bool UnlimitedDownloads { get; }
        /// <summary>
        /// Gets or sets the maximum number of downloads
        /// </summary>
         int MaxNumberOfDownloads { get; }
        /// <summary>
        /// Gets or sets the number of days during customers keeps access to the file.
        /// </summary>
         int? DownloadExpirationDays { get; }
        /// <summary>
        /// Gets or sets the download activation type
        /// </summary>
         int DownloadActivationTypeId { get; }
        /// <summary>
        /// Gets or sets a value indicating whether the product has a sample download file
        /// </summary>
         bool HasSampleDownload { get; }
        /// <summary>
        /// Gets or sets the sample download identifier
        /// </summary>
         int SampleDownloadId { get; }
        /// <summary>
        /// Gets or sets a value indicating whether the product has user agreement
        /// </summary>
         bool HasUserAgreement { get; }
        /// <summary>
        /// Gets or sets the text of license agreement
        /// </summary>
         string UserAgreementText { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is recurring
        /// </summary>
         bool IsRecurring { get; }
        /// <summary>
        /// Gets or sets the cycle length
        /// </summary>
         int RecurringCycleLength { get; }
        /// <summary>
        /// Gets or sets the cycle period
        /// </summary>
         int RecurringCyclePeriodId { get; }
        /// <summary>
        /// Gets or sets the total cycles
        /// </summary>
         int RecurringTotalCycles { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is rental
        /// </summary>
         bool IsRental { get; }
        /// <summary>
        /// Gets or sets the rental length for some period (price for this period)
        /// </summary>
         int RentalPriceLength { get; }
        /// <summary>
        /// Gets or sets the rental period (price for this period)
        /// </summary>
         int RentalPricePeriodId { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is ship enabled
        /// </summary>
         bool IsShipEnabled { get; }
        /// <summary>
        /// Gets or sets a value indicating whether the entity is free shipping
        /// </summary>
         bool IsFreeShipping { get; }
        /// <summary>
        /// Gets or sets a value this product should be shipped separately (each item)
        /// </summary>
         bool ShipSeparately { get; }
        /// <summary>
        /// Gets or sets the additional shipping charge
        /// </summary>
         decimal AdditionalShippingCharge { get; }
        /// <summary>
        /// Gets or sets a delivery date identifier
        /// </summary>
         int DeliveryDateId { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is marked as tax exempt
        /// </summary>
         bool IsTaxExempt { get; }
        /// <summary>
        /// Gets or sets the tax category identifier
        /// </summary>
         int TaxCategoryId { get; }
        /// <summary>
        /// Gets or sets a value indicating whether the product is telecommunications or broadcasting or electronic services
        /// </summary>
         bool IsTelecommunicationsOrBroadcastingOrElectronicServices { get; }

        /// <summary>
        /// Gets or sets a value indicating how to manage inventory
        /// </summary>
         int ManageInventoryMethodId { get; }
        /// <summary>
        /// Gets or sets a value indicating whether multiple warehouses are used for this product
        /// </summary>
         bool UseMultipleWarehouses { get; }
        /// <summary>
        /// Gets or sets a warehouse identifier
        /// </summary>
         int WarehouseId { get; }
        /// <summary>
        /// Gets or sets the stock quantity
        /// </summary>
         int StockQuantity { get; }
        /// <summary>
        /// Gets or sets a value indicating whether to display stock availability
        /// </summary>
         bool DisplayStockAvailability { get; }
        /// <summary>
        /// Gets or sets a value indicating whether to display stock quantity
        /// </summary>
         bool DisplayStockQuantity { get; }
        /// <summary>
        /// Gets or sets the minimum stock quantity
        /// </summary>
         int MinStockQuantity { get; }
        /// <summary>
        /// Gets or sets the low stock activity identifier
        /// </summary>
         int LowStockActivityId { get; }
        /// <summary>
        /// Gets or sets the quantity when admin should be notified
        /// </summary>
         int NotifyAdminForQuantityBelow { get; }
        /// <summary>
        /// Gets or sets a value backorder mode identifier
        /// </summary>
         int BackorderModeId { get; }
        /// <summary>
        /// Gets or sets a value indicating whether to back in stock subscriptions are allowed
        /// </summary>
         bool AllowBackInStockSubscriptions { get; }
        /// <summary>
        /// Gets or sets the order minimum quantity
        /// </summary>
         int OrderMinimumQuantity { get; }
        /// <summary>
        /// Gets or sets the order maximum quantity
        /// </summary>
         int OrderMaximumQuantity { get; }
        /// <summary>
        /// Gets or sets the comma seperated list of allowed quantities. null or empty if any quantity is allowed
        /// </summary>
         string AllowedQuantities { get; }
        /// <summary>
        /// Gets or sets a value indicating whether we allow adding to the cart/wishlist only attribute combinations that exist and have stock greater than zero.
        /// This option is used only when we have "manage inventory" set to "track inventory by product attributes"
        /// </summary>
         bool AllowAddingOnlyExistingAttributeCombinations { get; }

        /// <summary>
        /// Gets or sets a value indicating whether to disable buy (Add to cart) button
        /// </summary>
         bool DisableBuyButton { get; }
        /// <summary>
        /// Gets or sets a value indicating whether to disable "Add to wishlist" button
        /// </summary>
         bool DisableWishlistButton { get; }
        /// <summary>
        /// Gets or sets a value indicating whether this item is available for Pre-Order
        /// </summary>
         bool AvailableForPreOrder { get; }
        /// <summary>
        /// Gets or sets the start date and time of the product availability (for pre-order products)
        /// </summary>
         DateTime? PreOrderAvailabilityStartDateTimeUtc { get; }
        /// <summary>
        /// Gets or sets a value indicating whether to show "Call for Pricing" or "Call for quote" instead of price
        /// </summary>
         bool CallForPrice { get; }
        /// <summary>
        /// Gets or sets the price
        /// </summary>
         decimal Price { get; }
        /// <summary>
        /// Gets or sets the old price
        /// </summary>
         decimal OldPrice { get; }
        /// <summary>
        /// Gets or sets the product cost
        /// </summary>
         decimal ProductCost { get; }
        /// <summary>
        /// Gets or sets the product special price
        /// </summary>
         decimal? SpecialPrice { get; }
        /// <summary>
        /// Gets or sets the start date and time of the special price
        /// </summary>
         DateTime? SpecialPriceStartDateTimeUtc { get; }
        /// <summary>
        /// Gets or sets the end date and time of the special price
        /// </summary>
         DateTime? SpecialPriceEndDateTimeUtc { get; }
        /// <summary>
        /// Gets or sets a value indicating whether a customer enters price
        /// </summary>
         bool CustomerEntersPrice { get; }
        /// <summary>
        /// Gets or sets the minimum price entered by a customer
        /// </summary>
         decimal MinimumCustomerEnteredPrice { get; }
        /// <summary>
        /// Gets or sets the maximum price entered by a customer
        /// </summary>
         decimal MaximumCustomerEnteredPrice { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this product has tier prices configured
        /// <remarks>The same as if we run this.TierPrices.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load tier prices navifation property
        /// </remarks>
        /// </summary>
         bool HasTierPrices { get; }
        /// <summary>
        /// Gets or sets a value indicating whether this product has discounts applied
        /// <remarks>The same as if we run this.AppliedDiscounts.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load Applied Discounts navifation property
        /// </remarks>
        /// </summary>
         bool HasDiscountsApplied { get; }

        /// <summary>
        /// Gets or sets the weight
        /// </summary>
         decimal Weight { get; }
        /// <summary>
        /// Gets or sets the length
        /// </summary>
         decimal Length { get; }
        /// <summary>
        /// Gets or sets the width
        /// </summary>
         decimal Width { get; }
        /// <summary>
        /// Gets or sets the height
        /// </summary>
         decimal Height { get; }

        /// <summary>
        /// Gets or sets the available start date and time
        /// </summary>
         DateTime? AvailableStartDateTimeUtc { get; }
        /// <summary>
        /// Gets or sets the available end date and time
        /// </summary>
         DateTime? AvailableEndDateTimeUtc { get; }

        /// <summary>
        /// Gets or sets a display order.
        /// This value is used when sorting associated products (used with "grouped" products)
        /// This value is used when sorting home page products
        /// </summary>
         int DisplayOrder { get; }
        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
         bool Published { get; }
        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
         bool Deleted { get; }

        /// <summary>
        /// Gets or sets the date and time of product creation
        /// </summary>
         DateTime CreatedOnUtc { get; }
        /// <summary>
        /// Gets or sets the date and time of product update
        /// </summary>
         DateTime UpdatedOnUtc { get; }






        ///// <summary>
        ///// Gets or sets the product type
        ///// </summary>
        // ProductType ProductType {
        //    get {
        //        return (ProductType)this.ProductTypeId;
        //    }
        //    set {
        //        this.ProductTypeId = (int)value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the backorder mode
        ///// </summary>
        // BackorderMode BackorderMode {
        //    get {
        //        return (BackorderMode)this.BackorderModeId;
        //    }
        //    set {
        //        this.BackorderModeId = (int)value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the download activation type
        ///// </summary>
        // DownloadActivationType DownloadActivationType {
        //    get {
        //        return (DownloadActivationType)this.DownloadActivationTypeId;
        //    }
        //    set {
        //        this.DownloadActivationTypeId = (int)value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the gift card type
        ///// </summary>
        // GiftCardType GiftCardType {
        //    get {
        //        return (GiftCardType)this.GiftCardTypeId;
        //    }
        //    set {
        //        this.GiftCardTypeId = (int)value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the low stock activity
        ///// </summary>
        // LowStockActivity LowStockActivity {
        //    get {
        //        return (LowStockActivity)this.LowStockActivityId;
        //    }
        //    set {
        //        this.LowStockActivityId = (int)value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the value indicating how to manage inventory
        ///// </summary>
        // ManageInventoryMethod ManageInventoryMethod {
        //    get {
        //        return (ManageInventoryMethod)this.ManageInventoryMethodId;
        //    }
        //    set {
        //        this.ManageInventoryMethodId = (int)value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the cycle period for recurring products
        ///// </summary>
        // RecurringProductCyclePeriod RecurringCyclePeriod {
        //    get {
        //        return (RecurringProductCyclePeriod)this.RecurringCyclePeriodId;
        //    }
        //    set {
        //        this.RecurringCyclePeriodId = (int)value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the period for rental products
        ///// </summary>
        // RentalPricePeriod RentalPricePeriod {
        //    get {
        //        return (RentalPricePeriod)this.RentalPricePeriodId;
        //    }
        //    set {
        //        this.RentalPricePeriodId = (int)value;
        //    }
        //}






        ///// <summary>
        ///// Gets or sets the collection of ProductCategory
        ///// </summary>
        // virtual ICollection<ProductCategory> ProductCategories {
        //    get { return _productCategories ?? (_productCategories = new List<ProductCategory>()); }
        //    protected set { _productCategories = value; }
        //}

        ///// <summary>
        ///// Gets or sets the collection of ProductManufacturer
        ///// </summary>
        // virtual ICollection<ProductManufacturer> ProductManufacturers {
        //    get { return _productManufacturers ?? (_productManufacturers = new List<ProductManufacturer>()); }
        //    protected set { _productManufacturers = value; }
        //}

        ///// <summary>
        ///// Gets or sets the collection of ProductPicture
        ///// </summary>
        // virtual ICollection<ProductPicture> ProductPictures {
        //    get { return _productPictures ?? (_productPictures = new List<ProductPicture>()); }
        //    protected set { _productPictures = value; }
        //}

        ///// <summary>
        ///// Gets or sets the collection of product reviews
        ///// </summary>
        // virtual ICollection<ProductReview> ProductReviews {
        //    get { return _productReviews ?? (_productReviews = new List<ProductReview>()); }
        //    protected set { _productReviews = value; }
        //}

        ///// <summary>
        ///// Gets or sets the product specification attribute
        ///// </summary>
        // virtual ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes {
        //    get { return _productSpecificationAttributes ?? (_productSpecificationAttributes = new List<ProductSpecificationAttribute>()); }
        //    protected set { _productSpecificationAttributes = value; }
        //}

        ///// <summary>
        ///// Gets or sets the product tags
        ///// </summary>
        // virtual ICollection<ProductTag> ProductTags {
        //    get { return _productTags ?? (_productTags = new List<ProductTag>()); }
        //    protected set { _productTags = value; }
        //}

        ///// <summary>
        ///// Gets or sets the product attribute mappings
        ///// </summary>
        // virtual ICollection<ProductAttributeMapping> ProductAttributeMappings {
        //    get { return _productAttributeMappings ?? (_productAttributeMappings = new List<ProductAttributeMapping>()); }
        //    protected set { _productAttributeMappings = value; }
        //}

        ///// <summary>
        ///// Gets or sets the product attribute combinations
        ///// </summary>
        // virtual ICollection<ProductAttributeCombination> ProductAttributeCombinations {
        //    get { return _productAttributeCombinations ?? (_productAttributeCombinations = new List<ProductAttributeCombination>()); }
        //    protected set { _productAttributeCombinations = value; }
        //}

        ///// <summary>
        ///// Gets or sets the tier prices
        ///// </summary>
        // virtual ICollection<TierPrice> TierPrices {
        //    get { return _tierPrices ?? (_tierPrices = new List<TierPrice>()); }
        //    protected set { _tierPrices = value; }
        //}

        ///// <summary>
        ///// Gets or sets the collection of applied discounts
        ///// </summary>
        // virtual ICollection<Discount> AppliedDiscounts {
        //    get { return _appliedDiscounts ?? (_appliedDiscounts = new List<Discount>()); }
        //    protected set { _appliedDiscounts = value; }
        //}

        ///// <summary>
        ///// Gets or sets the collection of "ProductWarehouseInventory" records. We use it only when "UseMultipleWarehouses" is set to "true" and ManageInventoryMethod" to "ManageStock"
        ///// </summary>
        // virtual ICollection<ProductWarehouseInventory> ProductWarehouseInventory {
        //    get { return _productWarehouseInventory ?? (_productWarehouseInventory = new List<ProductWarehouseInventory>()); }
        //    protected set { _productWarehouseInventory = value; }
        //}




    }
}

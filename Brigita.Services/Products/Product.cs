 

using Brigita.Domain.Products;

namespace Brigita.Services.Products {

	class Product : IProduct
	{
		public System.Int32 ProductTypeId { get; set; }
		public System.Int32 ParentGroupedProductId { get; set; }
		public System.Boolean VisibleIndividually { get; set; }
		public System.String Name { get; set; }
		public System.String ShortDescription { get; set; }
		public System.String FullDescription { get; set; }
		public System.String AdminComment { get; set; }
		public System.Int32 ProductTemplateId { get; set; }
		public System.Int32 VendorId { get; set; }
		public System.Boolean ShowOnHomePage { get; set; }
		public System.String MetaKeywords { get; set; }
		public System.String MetaDescription { get; set; }
		public System.String MetaTitle { get; set; }
		public System.Boolean AllowCustomerReviews { get; set; }
		public System.Int32 ApprovedRatingSum { get; set; }
		public System.Int32 NotApprovedRatingSum { get; set; }
		public System.Int32 ApprovedTotalReviews { get; set; }
		public System.Int32 NotApprovedTotalReviews { get; set; }
		public System.Boolean SubjectToAcl { get; set; }
		public System.Boolean LimitedToStores { get; set; }
		public System.String Sku { get; set; }
		public System.String ManufacturerPartNumber { get; set; }
		public System.String Gtin { get; set; }
		public System.Boolean IsGiftCard { get; set; }
		public System.Int32 GiftCardTypeId { get; set; }
		public System.Boolean RequireOtherProducts { get; set; }
		public System.String RequiredProductIds { get; set; }
		public System.Boolean AutomaticallyAddRequiredProducts { get; set; }
		public System.Boolean IsDownload { get; set; }
		public System.Int32 DownloadId { get; set; }
		public System.Boolean UnlimitedDownloads { get; set; }
		public System.Int32 MaxNumberOfDownloads { get; set; }
		public System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] DownloadExpirationDays { get; set; }
		public System.Int32 DownloadActivationTypeId { get; set; }
		public System.Boolean HasSampleDownload { get; set; }
		public System.Int32 SampleDownloadId { get; set; }
		public System.Boolean HasUserAgreement { get; set; }
		public System.String UserAgreementText { get; set; }
		public System.Boolean IsRecurring { get; set; }
		public System.Int32 RecurringCycleLength { get; set; }
		public System.Int32 RecurringCyclePeriodId { get; set; }
		public System.Int32 RecurringTotalCycles { get; set; }
		public System.Boolean IsRental { get; set; }
		public System.Int32 RentalPriceLength { get; set; }
		public System.Int32 RentalPricePeriodId { get; set; }
		public System.Boolean IsShipEnabled { get; set; }
		public System.Boolean IsFreeShipping { get; set; }
		public System.Boolean ShipSeparately { get; set; }
		public System.Decimal AdditionalShippingCharge { get; set; }
		public System.Int32 DeliveryDateId { get; set; }
		public System.Boolean IsTaxExempt { get; set; }
		public System.Int32 TaxCategoryId { get; set; }
		public System.Boolean IsTelecommunicationsOrBroadcastingOrElectronicServices { get; set; }
		public System.Int32 ManageInventoryMethodId { get; set; }
		public System.Boolean UseMultipleWarehouses { get; set; }
		public System.Int32 WarehouseId { get; set; }
		public System.Int32 StockQuantity { get; set; }
		public System.Boolean DisplayStockAvailability { get; set; }
		public System.Boolean DisplayStockQuantity { get; set; }
		public System.Int32 MinStockQuantity { get; set; }
		public System.Int32 LowStockActivityId { get; set; }
		public System.Int32 NotifyAdminForQuantityBelow { get; set; }
		public System.Int32 BackorderModeId { get; set; }
		public System.Boolean AllowBackInStockSubscriptions { get; set; }
		public System.Int32 OrderMinimumQuantity { get; set; }
		public System.Int32 OrderMaximumQuantity { get; set; }
		public System.String AllowedQuantities { get; set; }
		public System.Boolean AllowAddingOnlyExistingAttributeCombinations { get; set; }
		public System.Boolean DisableBuyButton { get; set; }
		public System.Boolean DisableWishlistButton { get; set; }
		public System.Boolean AvailableForPreOrder { get; set; }
		public System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] PreOrderAvailabilityStartDateTimeUtc { get; set; }
		public System.Boolean CallForPrice { get; set; }
		public System.Decimal Price { get; set; }
		public System.Decimal OldPrice { get; set; }
		public System.Decimal ProductCost { get; set; }
		public System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] SpecialPrice { get; set; }
		public System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] SpecialPriceStartDateTimeUtc { get; set; }
		public System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] SpecialPriceEndDateTimeUtc { get; set; }
		public System.Boolean CustomerEntersPrice { get; set; }
		public System.Decimal MinimumCustomerEnteredPrice { get; set; }
		public System.Decimal MaximumCustomerEnteredPrice { get; set; }
		public System.Boolean HasTierPrices { get; set; }
		public System.Boolean HasDiscountsApplied { get; set; }
		public System.Decimal Weight { get; set; }
		public System.Decimal Length { get; set; }
		public System.Decimal Width { get; set; }
		public System.Decimal Height { get; set; }
		public System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] AvailableStartDateTimeUtc { get; set; }
		public System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] AvailableEndDateTimeUtc { get; set; }
		public System.Int32 DisplayOrder { get; set; }
		public System.Boolean Published { get; set; }
		public System.Boolean Deleted { get; set; }
		public System.DateTime CreatedOnUtc { get; set; }
		public System.DateTime UpdatedOnUtc { get; set; }
	}
}

 

using Brigita.Domain.Products;
using System;

namespace Brigita.Services.Products {

	class Product : IProduct
	{
		public int ProductTypeId { get; set; }
		public int ParentGroupedProductId { get; set; }
		public bool VisibleIndividually { get; set; }
		public string Name { get; set; }
		public string ShortDescription { get; set; }
		public string FullDescription { get; set; }
		public string AdminComment { get; set; }
		public int ProductTemplateId { get; set; }
		public int VendorId { get; set; }
		public bool ShowOnHomePage { get; set; }
		public string MetaKeywords { get; set; }
		public string MetaDescription { get; set; }
		public string MetaTitle { get; set; }
		public bool AllowCustomerReviews { get; set; }
		public int ApprovedRatingSum { get; set; }
		public int NotApprovedRatingSum { get; set; }
		public int ApprovedTotalReviews { get; set; }
		public int NotApprovedTotalReviews { get; set; }
		public bool SubjectToAcl { get; set; }
		public bool LimitedToStores { get; set; }
		public string Sku { get; set; }
		public string ManufacturerPartNumber { get; set; }
		public string Gtin { get; set; }
		public bool IsGiftCard { get; set; }
		public int GiftCardTypeId { get; set; }
		public bool RequireOtherProducts { get; set; }
		public string RequiredProductIds { get; set; }
		public bool AutomaticallyAddRequiredProducts { get; set; }
		public bool IsDownload { get; set; }
		public int DownloadId { get; set; }
		public bool UnlimitedDownloads { get; set; }
		public int MaxNumberOfDownloads { get; set; }
		public System.Nullable`1 DownloadExpirationDays { get; set; }
		public int DownloadActivationTypeId { get; set; }
		public bool HasSampleDownload { get; set; }
		public int SampleDownloadId { get; set; }
		public bool HasUserAgreement { get; set; }
		public string UserAgreementText { get; set; }
		public bool IsRecurring { get; set; }
		public int RecurringCycleLength { get; set; }
		public int RecurringCyclePeriodId { get; set; }
		public int RecurringTotalCycles { get; set; }
		public bool IsRental { get; set; }
		public int RentalPriceLength { get; set; }
		public int RentalPricePeriodId { get; set; }
		public bool IsShipEnabled { get; set; }
		public bool IsFreeShipping { get; set; }
		public bool ShipSeparately { get; set; }
		public System.Decimal AdditionalShippingCharge { get; set; }
		public int DeliveryDateId { get; set; }
		public bool IsTaxExempt { get; set; }
		public int TaxCategoryId { get; set; }
		public bool IsTelecommunicationsOrBroadcastingOrElectronicServices { get; set; }
		public int ManageInventoryMethodId { get; set; }
		public bool UseMultipleWarehouses { get; set; }
		public int WarehouseId { get; set; }
		public int StockQuantity { get; set; }
		public bool DisplayStockAvailability { get; set; }
		public bool DisplayStockQuantity { get; set; }
		public int MinStockQuantity { get; set; }
		public int LowStockActivityId { get; set; }
		public int NotifyAdminForQuantityBelow { get; set; }
		public int BackorderModeId { get; set; }
		public bool AllowBackInStockSubscriptions { get; set; }
		public int OrderMinimumQuantity { get; set; }
		public int OrderMaximumQuantity { get; set; }
		public string AllowedQuantities { get; set; }
		public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }
		public bool DisableBuyButton { get; set; }
		public bool DisableWishlistButton { get; set; }
		public bool AvailableForPreOrder { get; set; }
		public System.Nullable`1 PreOrderAvailabilityStartDateTimeUtc { get; set; }
		public bool CallForPrice { get; set; }
		public System.Decimal Price { get; set; }
		public System.Decimal OldPrice { get; set; }
		public System.Decimal ProductCost { get; set; }
		public System.Nullable`1 SpecialPrice { get; set; }
		public System.Nullable`1 SpecialPriceStartDateTimeUtc { get; set; }
		public System.Nullable`1 SpecialPriceEndDateTimeUtc { get; set; }
		public bool CustomerEntersPrice { get; set; }
		public System.Decimal MinimumCustomerEnteredPrice { get; set; }
		public System.Decimal MaximumCustomerEnteredPrice { get; set; }
		public bool HasTierPrices { get; set; }
		public bool HasDiscountsApplied { get; set; }
		public System.Decimal Weight { get; set; }
		public System.Decimal Length { get; set; }
		public System.Decimal Width { get; set; }
		public System.Decimal Height { get; set; }
		public System.Nullable`1 AvailableStartDateTimeUtc { get; set; }
		public System.Nullable`1 AvailableEndDateTimeUtc { get; set; }
		public int DisplayOrder { get; set; }
		public bool Published { get; set; }
		public bool Deleted { get; set; }
		public System.DateTime CreatedOnUtc { get; set; }
		public System.DateTime UpdatedOnUtc { get; set; }
	}
}

 

using Brigita.Domain.Products;
using System;

namespace Brigita.Services.Products {

	class Product : IProduct
	{
		public Int32 ProductTypeId { get; set; }
		public Int32 ParentGroupedProductId { get; set; }
		public Boolean VisibleIndividually { get; set; }
		public String Name { get; set; }
		public String ShortDescription { get; set; }
		public String FullDescription { get; set; }
		public String AdminComment { get; set; }
		public Int32 ProductTemplateId { get; set; }
		public Int32 VendorId { get; set; }
		public Boolean ShowOnHomePage { get; set; }
		public String MetaKeywords { get; set; }
		public String MetaDescription { get; set; }
		public String MetaTitle { get; set; }
		public Boolean AllowCustomerReviews { get; set; }
		public Int32 ApprovedRatingSum { get; set; }
		public Int32 NotApprovedRatingSum { get; set; }
		public Int32 ApprovedTotalReviews { get; set; }
		public Int32 NotApprovedTotalReviews { get; set; }
		public Boolean SubjectToAcl { get; set; }
		public Boolean LimitedToStores { get; set; }
		public String Sku { get; set; }
		public String ManufacturerPartNumber { get; set; }
		public String Gtin { get; set; }
		public Boolean IsGiftCard { get; set; }
		public Int32 GiftCardTypeId { get; set; }
		public Boolean RequireOtherProducts { get; set; }
		public String RequiredProductIds { get; set; }
		public Boolean AutomaticallyAddRequiredProducts { get; set; }
		public Boolean IsDownload { get; set; }
		public Int32 DownloadId { get; set; }
		public Boolean UnlimitedDownloads { get; set; }
		public Int32 MaxNumberOfDownloads { get; set; }
		public Nullable<Int32> DownloadExpirationDays { get; set; }
		public Int32 DownloadActivationTypeId { get; set; }
		public Boolean HasSampleDownload { get; set; }
		public Int32 SampleDownloadId { get; set; }
		public Boolean HasUserAgreement { get; set; }
		public String UserAgreementText { get; set; }
		public Boolean IsRecurring { get; set; }
		public Int32 RecurringCycleLength { get; set; }
		public Int32 RecurringCyclePeriodId { get; set; }
		public Int32 RecurringTotalCycles { get; set; }
		public Boolean IsRental { get; set; }
		public Int32 RentalPriceLength { get; set; }
		public Int32 RentalPricePeriodId { get; set; }
		public Boolean IsShipEnabled { get; set; }
		public Boolean IsFreeShipping { get; set; }
		public Boolean ShipSeparately { get; set; }
		public Decimal AdditionalShippingCharge { get; set; }
		public Int32 DeliveryDateId { get; set; }
		public Boolean IsTaxExempt { get; set; }
		public Int32 TaxCategoryId { get; set; }
		public Boolean IsTelecommunicationsOrBroadcastingOrElectronicServices { get; set; }
		public Int32 ManageInventoryMethodId { get; set; }
		public Boolean UseMultipleWarehouses { get; set; }
		public Int32 WarehouseId { get; set; }
		public Int32 StockQuantity { get; set; }
		public Boolean DisplayStockAvailability { get; set; }
		public Boolean DisplayStockQuantity { get; set; }
		public Int32 MinStockQuantity { get; set; }
		public Int32 LowStockActivityId { get; set; }
		public Int32 NotifyAdminForQuantityBelow { get; set; }
		public Int32 BackorderModeId { get; set; }
		public Boolean AllowBackInStockSubscriptions { get; set; }
		public Int32 OrderMinimumQuantity { get; set; }
		public Int32 OrderMaximumQuantity { get; set; }
		public String AllowedQuantities { get; set; }
		public Boolean AllowAddingOnlyExistingAttributeCombinations { get; set; }
		public Boolean DisableBuyButton { get; set; }
		public Boolean DisableWishlistButton { get; set; }
		public Boolean AvailableForPreOrder { get; set; }
		public Nullable<DateTime> PreOrderAvailabilityStartDateTimeUtc { get; set; }
		public Boolean CallForPrice { get; set; }
		public Decimal Price { get; set; }
		public Decimal OldPrice { get; set; }
		public Decimal ProductCost { get; set; }
		public Nullable<Decimal> SpecialPrice { get; set; }
		public Nullable<DateTime> SpecialPriceStartDateTimeUtc { get; set; }
		public Nullable<DateTime> SpecialPriceEndDateTimeUtc { get; set; }
		public Boolean CustomerEntersPrice { get; set; }
		public Decimal MinimumCustomerEnteredPrice { get; set; }
		public Decimal MaximumCustomerEnteredPrice { get; set; }
		public Boolean HasTierPrices { get; set; }
		public Boolean HasDiscountsApplied { get; set; }
		public Decimal Weight { get; set; }
		public Decimal Length { get; set; }
		public Decimal Width { get; set; }
		public Decimal Height { get; set; }
		public Nullable<DateTime> AvailableStartDateTimeUtc { get; set; }
		public Nullable<DateTime> AvailableEndDateTimeUtc { get; set; }
		public Int32 DisplayOrder { get; set; }
		public Boolean Published { get; set; }
		public Boolean Deleted { get; set; }
		public DateTime CreatedOnUtc { get; set; }
		public DateTime UpdatedOnUtc { get; set; }
		public Int32 ID { get; set; }

		public void PopulateFrom(Brigita.Domain.IEntity input) {
			this.ID = input.ID;
		}
	}
}

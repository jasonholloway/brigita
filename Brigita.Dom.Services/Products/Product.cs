 

using Brigita.Dom;
using Brigita.Dom.Products;
using System;

namespace Brigita.Dom.Services.Products {

	public partial class Product : IProduct, IEntity
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

		public void PopulateFrom(IProduct input) {
			this.ProductTypeId = input.ProductTypeId;
			this.ParentGroupedProductId = input.ParentGroupedProductId;
			this.VisibleIndividually = input.VisibleIndividually;
			this.Name = input.Name;
			this.ShortDescription = input.ShortDescription;
			this.FullDescription = input.FullDescription;
			this.AdminComment = input.AdminComment;
			this.ProductTemplateId = input.ProductTemplateId;
			this.VendorId = input.VendorId;
			this.ShowOnHomePage = input.ShowOnHomePage;
			this.MetaKeywords = input.MetaKeywords;
			this.MetaDescription = input.MetaDescription;
			this.MetaTitle = input.MetaTitle;
			this.AllowCustomerReviews = input.AllowCustomerReviews;
			this.ApprovedRatingSum = input.ApprovedRatingSum;
			this.NotApprovedRatingSum = input.NotApprovedRatingSum;
			this.ApprovedTotalReviews = input.ApprovedTotalReviews;
			this.NotApprovedTotalReviews = input.NotApprovedTotalReviews;
			this.SubjectToAcl = input.SubjectToAcl;
			this.LimitedToStores = input.LimitedToStores;
			this.Sku = input.Sku;
			this.ManufacturerPartNumber = input.ManufacturerPartNumber;
			this.Gtin = input.Gtin;
			this.IsGiftCard = input.IsGiftCard;
			this.GiftCardTypeId = input.GiftCardTypeId;
			this.RequireOtherProducts = input.RequireOtherProducts;
			this.RequiredProductIds = input.RequiredProductIds;
			this.AutomaticallyAddRequiredProducts = input.AutomaticallyAddRequiredProducts;
			this.IsDownload = input.IsDownload;
			this.DownloadId = input.DownloadId;
			this.UnlimitedDownloads = input.UnlimitedDownloads;
			this.MaxNumberOfDownloads = input.MaxNumberOfDownloads;
			this.DownloadExpirationDays = input.DownloadExpirationDays;
			this.DownloadActivationTypeId = input.DownloadActivationTypeId;
			this.HasSampleDownload = input.HasSampleDownload;
			this.SampleDownloadId = input.SampleDownloadId;
			this.HasUserAgreement = input.HasUserAgreement;
			this.UserAgreementText = input.UserAgreementText;
			this.IsRecurring = input.IsRecurring;
			this.RecurringCycleLength = input.RecurringCycleLength;
			this.RecurringCyclePeriodId = input.RecurringCyclePeriodId;
			this.RecurringTotalCycles = input.RecurringTotalCycles;
			this.IsRental = input.IsRental;
			this.RentalPriceLength = input.RentalPriceLength;
			this.RentalPricePeriodId = input.RentalPricePeriodId;
			this.IsShipEnabled = input.IsShipEnabled;
			this.IsFreeShipping = input.IsFreeShipping;
			this.ShipSeparately = input.ShipSeparately;
			this.AdditionalShippingCharge = input.AdditionalShippingCharge;
			this.DeliveryDateId = input.DeliveryDateId;
			this.IsTaxExempt = input.IsTaxExempt;
			this.TaxCategoryId = input.TaxCategoryId;
			this.IsTelecommunicationsOrBroadcastingOrElectronicServices = input.IsTelecommunicationsOrBroadcastingOrElectronicServices;
			this.ManageInventoryMethodId = input.ManageInventoryMethodId;
			this.UseMultipleWarehouses = input.UseMultipleWarehouses;
			this.WarehouseId = input.WarehouseId;
			this.StockQuantity = input.StockQuantity;
			this.DisplayStockAvailability = input.DisplayStockAvailability;
			this.DisplayStockQuantity = input.DisplayStockQuantity;
			this.MinStockQuantity = input.MinStockQuantity;
			this.LowStockActivityId = input.LowStockActivityId;
			this.NotifyAdminForQuantityBelow = input.NotifyAdminForQuantityBelow;
			this.BackorderModeId = input.BackorderModeId;
			this.AllowBackInStockSubscriptions = input.AllowBackInStockSubscriptions;
			this.OrderMinimumQuantity = input.OrderMinimumQuantity;
			this.OrderMaximumQuantity = input.OrderMaximumQuantity;
			this.AllowedQuantities = input.AllowedQuantities;
			this.AllowAddingOnlyExistingAttributeCombinations = input.AllowAddingOnlyExistingAttributeCombinations;
			this.DisableBuyButton = input.DisableBuyButton;
			this.DisableWishlistButton = input.DisableWishlistButton;
			this.AvailableForPreOrder = input.AvailableForPreOrder;
			this.PreOrderAvailabilityStartDateTimeUtc = input.PreOrderAvailabilityStartDateTimeUtc;
			this.CallForPrice = input.CallForPrice;
			this.Price = input.Price;
			this.OldPrice = input.OldPrice;
			this.ProductCost = input.ProductCost;
			this.SpecialPrice = input.SpecialPrice;
			this.SpecialPriceStartDateTimeUtc = input.SpecialPriceStartDateTimeUtc;
			this.SpecialPriceEndDateTimeUtc = input.SpecialPriceEndDateTimeUtc;
			this.CustomerEntersPrice = input.CustomerEntersPrice;
			this.MinimumCustomerEnteredPrice = input.MinimumCustomerEnteredPrice;
			this.MaximumCustomerEnteredPrice = input.MaximumCustomerEnteredPrice;
			this.HasTierPrices = input.HasTierPrices;
			this.HasDiscountsApplied = input.HasDiscountsApplied;
			this.Weight = input.Weight;
			this.Length = input.Length;
			this.Width = input.Width;
			this.Height = input.Height;
			this.AvailableStartDateTimeUtc = input.AvailableStartDateTimeUtc;
			this.AvailableEndDateTimeUtc = input.AvailableEndDateTimeUtc;
			this.DisplayOrder = input.DisplayOrder;
			this.Published = input.Published;
			this.Deleted = input.Deleted;
			this.CreatedOnUtc = input.CreatedOnUtc;
			this.UpdatedOnUtc = input.UpdatedOnUtc;
			this.ID = input.ID;
		}

		public void PopulateFrom(IEntity input) {
			this.ID = input.ID;
		}
	}
}

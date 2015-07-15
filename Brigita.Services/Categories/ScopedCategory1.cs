 

using Brigita.Domain;
using Brigita.Domain.Categories;
using System;

namespace Brigita.Services.Categories {

	partial class ScopedCategory : IScopedCategory, ICategory, IEntity
	{
		public Boolean IsActive { get; set; }
		public Boolean IsActiveParent { get; set; }
		public String Name { get; set; }
		public String Description { get; set; }
		public Int32 ParentCategoryId { get; set; }
		public Int32 PictureId { get; set; }
		public Int32 DisplayOrder { get; set; }
		public Boolean Published { get; set; }
		public Boolean Deleted { get; set; }
		public DateTime CreatedOnUtc { get; set; }
		public DateTime UpdatedOnUtc { get; set; }
		public Int32 CategoryTemplateId { get; set; }
		public String MetaKeywords { get; set; }
		public String MetaDescription { get; set; }
		public String MetaTitle { get; set; }
		public Int32 PageSize { get; set; }
		public Boolean AllowCustomersToSelectPageSize { get; set; }
		public String PageSizeOptions { get; set; }
		public String PriceRanges { get; set; }
		public Boolean ShowOnHomePage { get; set; }
		public Boolean IncludeInTopMenu { get; set; }
		public Boolean HasDiscountsApplied { get; set; }
		public Boolean SubjectToAcl { get; set; }
		public Boolean LimitedToStores { get; set; }
		public Int32 ID { get; set; }

		public void PopulateFrom(IScopedCategory input) {
			this.IsActive = input.IsActive;
			this.IsActiveParent = input.IsActiveParent;
			this.Name = input.Name;
			this.Description = input.Description;
			this.ParentCategoryId = input.ParentCategoryId;
			this.PictureId = input.PictureId;
			this.DisplayOrder = input.DisplayOrder;
			this.Published = input.Published;
			this.Deleted = input.Deleted;
			this.CreatedOnUtc = input.CreatedOnUtc;
			this.UpdatedOnUtc = input.UpdatedOnUtc;
			this.CategoryTemplateId = input.CategoryTemplateId;
			this.MetaKeywords = input.MetaKeywords;
			this.MetaDescription = input.MetaDescription;
			this.MetaTitle = input.MetaTitle;
			this.PageSize = input.PageSize;
			this.AllowCustomersToSelectPageSize = input.AllowCustomersToSelectPageSize;
			this.PageSizeOptions = input.PageSizeOptions;
			this.PriceRanges = input.PriceRanges;
			this.ShowOnHomePage = input.ShowOnHomePage;
			this.IncludeInTopMenu = input.IncludeInTopMenu;
			this.HasDiscountsApplied = input.HasDiscountsApplied;
			this.SubjectToAcl = input.SubjectToAcl;
			this.LimitedToStores = input.LimitedToStores;
			this.ID = input.ID;
			this.ID = input.ID;
		}

		public void PopulateFrom(ICategory input) {
			this.Name = input.Name;
			this.Description = input.Description;
			this.ParentCategoryId = input.ParentCategoryId;
			this.PictureId = input.PictureId;
			this.DisplayOrder = input.DisplayOrder;
			this.Published = input.Published;
			this.Deleted = input.Deleted;
			this.CreatedOnUtc = input.CreatedOnUtc;
			this.UpdatedOnUtc = input.UpdatedOnUtc;
			this.CategoryTemplateId = input.CategoryTemplateId;
			this.MetaKeywords = input.MetaKeywords;
			this.MetaDescription = input.MetaDescription;
			this.MetaTitle = input.MetaTitle;
			this.PageSize = input.PageSize;
			this.AllowCustomersToSelectPageSize = input.AllowCustomersToSelectPageSize;
			this.PageSizeOptions = input.PageSizeOptions;
			this.PriceRanges = input.PriceRanges;
			this.ShowOnHomePage = input.ShowOnHomePage;
			this.IncludeInTopMenu = input.IncludeInTopMenu;
			this.HasDiscountsApplied = input.HasDiscountsApplied;
			this.SubjectToAcl = input.SubjectToAcl;
			this.LimitedToStores = input.LimitedToStores;
			this.ID = input.ID;
		}

		public void PopulateFrom(IEntity input) {
			this.ID = input.ID;
		}
	}
}

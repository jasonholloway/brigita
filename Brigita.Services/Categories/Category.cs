 

using Brigita.Domain.Categories;
using System;

namespace Brigita.Services.Categories {

	class Category : ICategory
	{
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

		public void PopulateFrom(Brigita.Domain.IEntity input) {
			this.ID = input.ID;
		}
	}
}

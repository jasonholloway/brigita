using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Categories
{
    public interface ICategory : ITinyCategory
    {
        string Description { get; }
        int ParentCategoryId { get; }
        int PictureId { get; }

        int DisplayOrder { get; }
        bool Published { get; }
        bool Deleted { get; }
        DateTime CreatedOnUtc { get; }
        DateTime UpdatedOnUtc { get; }


        int CategoryTemplateId { get; }

        string MetaKeywords { get; }
        string MetaDescription { get; }
        string MetaTitle { get; }

        

        int PageSize { get; }
        bool AllowCustomersToSelectPageSize { get; }
        string PageSizeOptions { get; }

        string PriceRanges { get; }

        bool ShowOnHomePage { get; }
        bool IncludeInTopMenu { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this category has discounts applied
        /// <remarks>The same as if we run category.AppliedDiscounts.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load Applied Discounts navifation property
        /// </remarks>
        /// </summary>
         bool HasDiscountsApplied { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is subject to ACL
        /// </summary>
        bool SubjectToAcl { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        bool LimitedToStores { get; }

    }
}

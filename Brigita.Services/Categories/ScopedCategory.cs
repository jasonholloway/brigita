using Brigita.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Categories
{
    public class ScopedCategory : IScopedCategory
    {
        ICategory _baseCat;
        
        public ScopedCategory(ICategory baseCat, bool isActive, bool isActiveParent) {
            _baseCat = baseCat;

            IsActive = isActive;
            IsActiveParent = isActiveParent;
        }


        public bool IsActive { get; private set; }

        public bool IsActiveParent { get; private set; }


        public int ID {
            get { return _baseCat.ID; }
        }

        public string Name { 
            get { return _baseCat.Name; } 
        }

        public string Description {
            get { return _baseCat.Description; }
        }

        public int ParentCategoryId {
            get { return _baseCat.ParentCategoryId; }
        }

        public int PictureId {
            get { return _baseCat.PictureId; }
        }

        public int DisplayOrder {
            get { return _baseCat.DisplayOrder; }
        }

        public bool Published {
            get { return _baseCat.Published; }
        }

        public bool Deleted {
            get { return _baseCat.Deleted; }
        }

        public DateTime CreatedOnUtc {
            get { return _baseCat.CreatedOnUtc; }
        }

        public DateTime UpdatedOnUtc {
            get { return _baseCat.UpdatedOnUtc; }
        }

        public int CategoryTemplateId {
            get { return _baseCat.CategoryTemplateId; }
        }

        public string MetaKeywords {
            get { return _baseCat.MetaKeywords; }
        }

        public string MetaDescription {
            get { return _baseCat.MetaDescription; }
        }

        public string MetaTitle {
            get { return _baseCat.MetaTitle; }
        }

        public int PageSize {
            get { return _baseCat.PageSize; }
        }

        public bool AllowCustomersToSelectPageSize {
            get { return _baseCat.AllowCustomersToSelectPageSize; }
        }

        public string PageSizeOptions {
            get { return _baseCat.PageSizeOptions; }
        }

        public string PriceRanges {
            get { return _baseCat.PriceRanges; }
        }

        public bool ShowOnHomePage {
            get { return _baseCat.ShowOnHomePage; }
        }

        public bool IncludeInTopMenu {
            get { return _baseCat.IncludeInTopMenu; }
        }

        public bool HasDiscountsApplied {
            get { return _baseCat.HasDiscountsApplied; }
        }

        public bool SubjectToAcl {
            get { return _baseCat.SubjectToAcl; }
        }

        public bool LimitedToStores {
            get { return _baseCat.SubjectToAcl; }
        }
    }
}

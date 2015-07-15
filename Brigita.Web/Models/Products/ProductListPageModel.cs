 

using Brigita.Domain.Products;
using Brigita.Web.Domain.Infrastructure;
using Brigita.Web.Domain.Models;
using System;

namespace Brigita.Web.Model.Products {

	partial class ProductListPageModel : IWebPageModel, IPagedItemsModel<IProduct>
	{
		public IWebPageInfo WebPage { get; set; }
		public IListPage<IProduct> List { get; set; }

		public void PopulateFrom(IWebPageModel input) {
			this.WebPage = input.WebPage;
		}

		public void PopulateFrom(IPagedItemsModel<IProduct> input) {
			this.List = input.ListPage;
		}
	}
}

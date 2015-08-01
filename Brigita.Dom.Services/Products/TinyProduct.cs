 

using Brigita.Dom;
using Brigita.Dom.Products;
using System;

namespace Brigita.Dom.Services.Products {

	public partial class TinyProduct : ITinyProduct, IEntity
	{
		public String Name { get; set; }
		public String ShortDescription { get; set; }
		public Decimal Price { get; set; }
		public Nullable<Int32> PictureID { get; set; }
		public Int32 ID { get; set; }

		public void PopulateFrom(ITinyProduct input) {
			this.Name = input.Name;
			this.ShortDescription = input.ShortDescription;
			this.Price = input.Price;
			this.PictureID = input.PictureID;
			this.ID = input.ID;
		}

		public void PopulateFrom(IEntity input) {
			this.ID = input.ID;
		}
	}
}

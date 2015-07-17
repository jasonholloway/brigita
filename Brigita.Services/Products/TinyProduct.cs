 

using Brigita.Domain;
using Brigita.Domain.Products;
using System;

namespace Brigita.Services.Products {

	partial class TinyProduct : ITinyProduct, IEntity
	{
		public String Name { get; set; }
		public String ShortDescription { get; set; }
		public Decimal Price { get; set; }
		public Object Picture { get; set; }
		public Int32 ID { get; set; }

		public void PopulateFrom(ITinyProduct input) {
			this.Name = input.Name;
			this.ShortDescription = input.ShortDescription;
			this.Price = input.Price;
			this.Picture = input.Picture;
			this.ID = input.ID;
		}

		public void PopulateFrom(IEntity input) {
			this.ID = input.ID;
		}
	}
}

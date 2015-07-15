using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Web.Domain.Models
{
    public interface IProductContextModel
    {
        int CurrentCategoryID { get; }
    }
}

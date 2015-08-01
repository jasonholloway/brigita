using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.Media;

namespace Brigita.Dom.Services.Media
{
    public interface IPiccies
    {
        Piccy GetByID(int pictureID);        
    }
}

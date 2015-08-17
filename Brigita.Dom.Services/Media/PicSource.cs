using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Data;
using Nop.Core.Data;
using Nop.Core.Domain.Media;
using Nop.Services.Media;

namespace Brigita.Dom.Services.Media
{
    public class PicSource : IPicSource 
    {
        IPictureService _pics;
        IRepo<Picture> _picRepo;

        public PicSource(IPictureService pics, IRepo<Picture> picRepo) {
            _pics = pics;
            _picRepo = picRepo;
        }

        //To be cached here!
        public Pic GetByID(int pictureID) 
        {
            var piccy = _picRepo
                            .Select(p => new Pic() {
                                Id = p.ID,
                                AltText = p.TitleAttribute,
                                Url = null
                            })
                            .First(p => p.Id == pictureID);

            piccy.Url = _pics.GetPictureUrl(piccy.Id);

            return piccy;
        }
    }
}

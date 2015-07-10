using Brigita.Services.Cache;
using Nop.Core.Data;
using Nop.Core.Domain.Stores;
using Nop.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Stores
{
    [CacheZone("Stores")]
    public class BrigitaStores : IStoreService
    {        
        IRepository<Store> _repo;
        
        public BrigitaStores(IRepository<Store> repo) {
            _repo = repo;
        }


        [Cache("All")]
        public IList<Store> GetAllStores() {
            return _repo.Table.ToArray();
        }



        public Store GetStoreById(int storeId) {
            return GetAllStores()
                        .FirstOrDefault(s => s.ID == storeId);
        }

        public void InsertStore(Store store) {
            throw new NotImplementedException();
        }

        public void UpdateStore(Store store) {
            throw new NotImplementedException();
        }

        public void DeleteStore(Store store) {
            throw new NotImplementedException();
        }

    }
}

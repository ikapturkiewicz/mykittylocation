using MyKittyLocation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyKittyLocation.Repositories
{
    public interface ICatRepo
    {
        CatModel Get(int catId);
        IQueryable<CatModel> GetUserCats(string ownerName);
        void Add(CatModel cat);
        void Update(int catId, CatModel cat);
        void Delete(int catId);
    }
}

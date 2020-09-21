using Microsoft.EntityFrameworkCore;
using MyKittyLocation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Security;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MyKittyLocation.Repositories
{
    public class CatRepo : ICatRepo
    {
        private readonly KittyLocationContext _context;
        public CatRepo(KittyLocationContext context)
        {
            _context = context;
        }
        public CatModel Get(int catId)

        => _context.Cats.SingleOrDefault(x => x.CatId == catId);

        public IQueryable<CatModel> GetUserCats(string ownerName) {
            return _context.Cats.Where(x => x.OwnerID == ownerName);
        
         }

        public void Add(CatModel cat)
        {
            _context.Cats.Add(cat);
            _context.SaveChanges();
        }

        public void Update(int catId, CatModel cat)
        {
            var result = _context.Cats.SingleOrDefault(x => x.CatId == catId);
            if (result != null)
            {
                result.CollarId = cat.CollarId;
                result.Name = cat.Name;
                result.Photo = cat.Photo;

                _context.SaveChanges();
            }
        }

        public void Delete(int catId)
        {
            var result = _context.Cats.SingleOrDefault(x => x.CatId == catId);
            if (result != null)
            {
                _context.Cats.Remove(result);
                _context.SaveChanges();
            }
        }

        
    }
}

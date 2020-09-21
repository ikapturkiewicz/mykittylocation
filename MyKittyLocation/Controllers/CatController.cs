using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyKittyLocation.Models;
using MyKittyLocation.Repositories;


namespace MyKittyLocation.Controllers
{
    public class CatController : Controller
    {
        private readonly ICatRepo _catRepo;

        public CatController(ICatRepo catRepo)
        {
            _catRepo = catRepo;
        }


        // GET: Cat
        
        public ActionResult Index()
        {  
            return View("Index", _catRepo.GetUserCats(User.FindFirst(ClaimTypes.Email).Value));
        }

        public ActionResult Logout()
        {
            Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);
            return Index();
        }

        // GET: Cat/Details/5

        public ActionResult Details(int id)
        {

            return View(_catRepo.Get(id));
        }


        // GET: Cat/Create
        
        public ActionResult Create()
        {
            return View(new CatModel());
        }

        // POST: Cat/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CatModel catModel)
        {
            if (HttpContext.Request.Form.Files.Any())
            {
                var photo = HttpContext.Request.Form.Files[0];

                MemoryStream ms = new MemoryStream();
                photo.CopyTo(ms);
                var photoArray = ms.ToArray();
                catModel.Photo = photoArray;
            }
            catModel.OwnerID = User.FindFirst(ClaimTypes.Email).Value;
            _catRepo.Add(catModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Cat/Edit/5
        
        public ActionResult Edit(int id)
        {
            return View(_catRepo.Get(id));
        }

        // POST: Cat/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CatModel catModel)
        {
            var photo = HttpContext.Request.Form.Files[0];
            MemoryStream ms = new MemoryStream();
            photo.CopyTo(ms);
            var photoArray = ms.ToArray();
            catModel.Photo = photoArray;
            _catRepo.Update(id, catModel);

            return RedirectToAction(nameof(Index));
        }

        // GET: Cat/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_catRepo.Get(id));
        }

        // POST: Cat/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CatModel catModel)
        {
            _catRepo.Delete(id);

            return RedirectToAction(nameof(Index));

        }

       
    }
}

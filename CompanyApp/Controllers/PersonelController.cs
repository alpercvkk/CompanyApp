using CompanyApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace CompanyApp.Controllers
{
    [Authorize(AuthenticationSchemes = "EKOM1907")]
    public class PersonelController : Controller
    {


        [HttpGet]
        public IActionResult PersonelList()
        {

            var db = new CompanyAppDbContext();

            var clist = db.Personels.Include(x => x.Cities).Include(x => x.Counties).ToList();

            return View(clist);
        }

        [HttpGet]
        public IActionResult AddPersonel()
        {
            var db = new CompanyAppDbContext();

            var clist = db.Personels.Include(x => x.Cities).Include(x => x.Counties).ToList();

            ViewBag.Cities = db.Cities.ToList();
            ViewBag.Counties = db.Counties.ToList();

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddPersonel(Personel personel)
        {
            var db = new CompanyAppDbContext();

            ViewBag.Cities = db.Cities.ToList();
            ViewBag.Counties = db.Counties.ToList();

            if (ModelState.IsValid)
            {
                db.Personels.Update(personel);

                db.SaveChanges();

                ModelState.Clear();

                ViewBag.Message = "Personel Başarı ile Eklendi";
            }
            else
            {
                ViewBag.Message2 = "Lütfen Girdiğiniz Değerleri Kontrol ediniz";
            }
            return View();
        }

        public IActionResult City([FromBody] int? selectedValue)
        {
            return ViewComponent("City", new { CityId = selectedValue });
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {

            var db = new CompanyAppDbContext();

            var personel = db.Personels.Find(id);

            return View(personel);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]

        public IActionResult Delete(Personel personel)
        {
            var db = new CompanyAppDbContext();

            db.Personels.Remove(personel);
            db.SaveChanges();

            return RedirectToAction("PersonelList", "Personel");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var db = new CompanyAppDbContext();

            ViewBag.Cities = db.Cities.ToList();
            ViewBag.Counties = db.Counties.ToList();

            var personel = db.Personels.Find(id);

            return View(personel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]

        public IActionResult Update(Personel personel)
        {
            var db = new CompanyAppDbContext();

            ViewBag.Cities = db.Cities.ToList();
            ViewBag.Counties = db.Counties.ToList();

            if(ModelState.IsValid)
            {
                db.Personels.Update(personel);
                db.SaveChanges();
                ModelState.Clear();
            }

            
            return RedirectToAction("PersonelList" , "Personel");
        }


    }
}

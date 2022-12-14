using Microsoft.AspNetCore.Mvc;
using Borealis_App.Data;
using Borealis_App.Models;

namespace Borealis_App.Controllers
{
    public class ZapisiController : Controller
    {
        private readonly AppDbContext _db;
        public ZapisiController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Upravitelj()
        {
            IEnumerable<Zapisi> ZapisiList = _db.zapisi;
            ZapisiList = ZapisiList.OrderBy(x => x.Prihvaceno); // FILTER ZA PRIHVACENE
            return View(ZapisiList);
        }

        public IActionResult Index()
        {
            IEnumerable<Zapisi> ZapisiList = _db.zapisi;
            ZapisiList = ZapisiList.OrderBy(x => x.vrijeme).Where(x => x.Prihvaceno == true); // FILTER ZA PRIHVACENE
            return View(ZapisiList);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ZapisiIzBaze = _db.zapisi.Find(id);
            //var ZapisiIzBazePrvi = _db.zapisi.FirstOrDefault(x=>x.IDzapisa==id);
            //var ZapisiIzBazeJedan = _db.zapisi.FirstOrDefault(x => x.IDzapisa == id);

            if (ZapisiIzBaze == null)
            {
                return NotFound();
            }
            return View(ZapisiIzBaze);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Zapisi obj)
        {
            if (obj.Ime == obj.Prezime)
            {
                ModelState.AddModelError("PonavljaSe", "Ne moze biti isto ime i prezime");
            }
            if (ModelState.IsValid)
            {
                _db.zapisi.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Upravitelj");
            }
            return View(obj);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Zapisi zapis)
        {
            if (zapis.Ime == zapis.Prezime)
            {
                ModelState.AddModelError("PonavljaSe", "Ne moze biti isto ime i prezime");
            }
            if (ModelState.IsValid)
            {
                _db.zapisi.Add(zapis);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zapis);
        }



        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ZapisiIzBaze = _db.zapisi.Find(id);
            //var ZapisiIzBazePrvi = _db.zapisi.FirstOrDefault(x=>x.IDzapisa==id);
            //var ZapisiIzBazeJedan = _db.zapisi.FirstOrDefault(x => x.IDzapisa == id);

            if (ZapisiIzBaze == null)
            {
                return NotFound();
            }
            return View(ZapisiIzBaze);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Zapisi zapis)
        {
            var obj = _db.zapisi.Find(zapis.IDzapisa);
            if (obj == null)
            {
                return NotFound();
            }
            _db.zapisi.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Prihvati(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ZapisiIzBaze = _db.zapisi.Find(id);
            //var ZapisiIzBazePrvi = _db.zapisi.FirstOrDefault(x=>x.IDzapisa==id);
            //var ZapisiIzBazeJedan = _db.zapisi.FirstOrDefault(x => x.IDzapisa == id);

            if(ZapisiIzBaze != null)
            {
                ZapisiIzBaze.Prihvaceno = true;
                _db.zapisi.Update(ZapisiIzBaze);
                _db.SaveChanges();
            }

            if (ZapisiIzBaze == null)
            {
                return NotFound();
            }
            return RedirectToAction("Upravitelj");
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PrihvatiPOST(int? id)
        {
            var ZapisiIzBaze = _db.zapisi.Find(id);
            ZapisiIzBaze.Prihvaceno = true;
            if (ModelState.IsValid)
            {
                _db.zapisi.Update(ZapisiIzBaze);
                _db.SaveChanges();
                return RedirectToAction("Upravitelj");
            }
            return RedirectToAction("Upravitelj");
        }
    }
}

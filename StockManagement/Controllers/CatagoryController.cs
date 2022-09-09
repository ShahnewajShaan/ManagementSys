using Microsoft.AspNetCore.Mvc;
using StockManagement.Data;
using StockManagement.Models;
namespace StockManagement.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CatagoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Catagory> ObjectCatagorylist = _db.Catagories;
            return View(ObjectCatagorylist);
        }

        //get
        public IActionResult Create()
        {

            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catagory obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomerError", "Both Cannot Exactly Match");
            }
            if (ModelState.IsValid)
            {
                _db.Catagories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catagoryFromDb  = _db.Catagories.Find(id);

           // var catagoryFromDbFirst = _db.Catagories.FirstOrDefault(u => u.Id == id);
            // var CatagoryFromDbSingle = _db.Catagories.SingleOrDefault(u => u.Id == id);
            if (catagoryFromDb == null)
            {
                return NotFound();
            }

            return View(catagoryFromDb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Catagory obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomerError", "Both Cannot Exactly Match");
            }
            if (ModelState.IsValid)
            {
                _db.Catagories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catagoryFromDb = _db.Catagories.Find(id);

            // var catagoryFromDbFirst = _db.Catagories.FirstOrDefault(u => u.Id == id);
            // var CatagoryFromDbSingle = _db.Catagories.SingleOrDefault(u => u.Id == id);
            if (catagoryFromDb == null)
            {
                return NotFound();
            }

            return View(catagoryFromDb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Catagories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                _db.Catagories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
          
        }



    }

}

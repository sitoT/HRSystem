using HRSystem.Data;
using HRSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Controllers
{
    public class StaffController : Controller
    {
        public readonly ApplicationDbContext _db;

        public StaffController(ApplicationDbContext db)
        {
            _db = db;
        }




        public IActionResult Index()
        {

            IEnumerable<Staff> Staffs = _db.staff;
            return View(Staffs);
        }
        
        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Staff obj)
        {
            if (ModelState.IsValid)
            {
                _db.staff.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Staff Successfully Created";
                return RedirectToAction("Index");

            }

            return View(obj);
        } 
        public IActionResult Edit(int id)
        {
            var objOfStaff = _db.staff.Find(id);
            if (objOfStaff == null)
            {
                return NotFound();
            }
            return View(objOfStaff);
        }

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Staff obj)
        {
           

            if (ModelState.IsValid)
            {
                _db.staff.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Edit was Successful";
                return RedirectToAction("Index");

            }

            return View(obj);


        }
        
        public IActionResult Delete(int id)
        {
            var objOfStaff = _db.staff.Find(id);
            if (objOfStaff == null)
            {
                return NotFound();
            }
            return View(objOfStaff);
        }

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStaff(Staff obj)
        {
            _db.staff.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Item Deleted Successfully";
            return RedirectToAction("Index");

           
        }
    }
}

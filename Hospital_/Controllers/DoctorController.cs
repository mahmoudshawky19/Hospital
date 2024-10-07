using Hospital_.Data;
using Hospital_.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_.Controllers
{
    public class DoctorController : Controller
    {ApplicationDbContext dbContext = new ApplicationDbContext();
        public IActionResult Index()
        {
            var ds = dbContext.Doctors.ToList();
            return View(model:ds);
        }
        public IActionResult CompeleteAppointment(int doctorid)
        {
            var dId = dbContext.Doctors.Find(doctorid);
            if (dId == null)
            {
                return RedirectToAction("NotFoundPage");

            }
            else
            {
                return View(model: dId);

            }
        }
        public IActionResult NotFoundPage()
        {
            return View();
        }
        public IActionResult Display()
        {
            var pts = dbContext.Patients.ToList();
            return View(model: pts);
        }

        public IActionResult SaveNew(Patient p)
        {
             dbContext.Patients.Add(p);
            dbContext.SaveChanges();

            return RedirectToAction("");
        }


    }
}

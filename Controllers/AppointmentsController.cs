using Microsoft.AspNetCore.Mvc;
using SchedulingApp.Models;

namespace SchedulingApp.Controllers
{
  public class AppointmentsController : Controller
  {
    public IActionResult Index()
    {
      var appointments = new List<Appointment>
            {
                new Appointment
                {
                    Id = 1,
                    Title = "Eye Exam",
                    Date = DateTime.Today,
                    ClientName = "John Doe"
                },
                new Appointment
                {
                    Id = 2,
                    Title = "Follow-up",
                    Date = DateTime.Today.AddDays(1),
                    ClientName = "Jane Smith"
                }
            };

      return View(appointments);
    }
    public IActionResult Create()
    {
      return View();
    }
    [HttpPost]
    [HttpPost]
    public IActionResult Create(Appointment appointment)
    {
      if (!ModelState.IsValid)
      {
        return View(appointment);
      }

      // Later: save to database
      return RedirectToAction(nameof(Index));
    }



  }
}

using Microsoft.AspNetCore.Mvc;
using SchedulingApp.Data;
using SchedulingApp.Models;

namespace SchedulingApp.Controllers
{
  public class AppointmentsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public AppointmentsController(ApplicationDbContext context)
    {
      _context = context;
    }

    public IActionResult Index()
    {
      var today = DateTime.Today;

      // Get Monday of current week
      int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
      var weekStart = today.AddDays(-diff);
      var weekEnd = weekStart.AddDays(5);

      var model = new WeeklyAgendaViewModel
      {
        WeekStart = weekStart,
        WeekEnd = weekEnd,
        Days = Enumerable.Range(0, 5)
              .Select(d => weekStart.AddDays(d))
              .ToList(),
        Hours = Enumerable.Range(7, 13).ToList(), // 7 AM → 7 PM
        Appointments = _context.Appointments
              .Where(a => a.Date >= weekStart && a.Date < weekEnd.AddDays(1))
              .ToList()
      };

      return View(model);
    }


    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Appointment appointment)
    {
      if (!ModelState.IsValid)
      {
        return View(appointment);
      }

      _context.Appointments.Add(appointment);
      _context.SaveChanges();

      return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
      var appointment = _context.Appointments.Find(id);

      if (appointment == null)
      {
        return NotFound();
      }

      return View(appointment);
    }

    [HttpPost]
    public IActionResult Edit(Appointment appointment)
    {
      if (!ModelState.IsValid)
      {
        return View(appointment);
      }

      _context.Appointments.Update(appointment);
      _context.SaveChanges();

      return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
      var appointment = _context.Appointments.Find(id);

      if (appointment == null)
      {
        return NotFound();
      }

      return View(appointment);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
      var appointment = _context.Appointments.Find(id);

      if (appointment != null)
      {
        _context.Appointments.Remove(appointment);
        _context.SaveChanges();
      }

      return RedirectToAction(nameof(Index));
    }


  }
}

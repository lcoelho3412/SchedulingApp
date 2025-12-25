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
      var appointments = _context.Appointments.ToList();
      return View(appointments);
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

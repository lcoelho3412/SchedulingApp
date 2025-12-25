namespace SchedulingApp.Models
{
  public class WeeklyAgendaViewModel
  {
    public DateTime WeekStart { get; set; }
    public DateTime WeekEnd { get; set; }

    public List<DateTime> Days { get; set; } = new();
    public List<int> Hours { get; set; } = new();

    public List<Appointment> Appointments { get; set; } = new();
  }
}

using System.ComponentModel.DataAnnotations;

namespace SchedulingApp.Models
{
  public class Appointment
  {
    public int Id { get; set; }

    [Required]
    public required string Title { get; set; }

    [Required]
    public required string ClientName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
  }
}

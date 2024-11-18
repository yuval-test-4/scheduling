using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Infrastructure.Models;

[Table("Meetings")]
public class MeetingDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? Date { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Subject { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}

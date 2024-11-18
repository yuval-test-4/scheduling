namespace Scheduling.APIs.Dtos;

public class MeetingCreateInput
{
    public DateTime CreatedAt { get; set; }

    public DateTime? Date { get; set; }

    public string? Id { get; set; }

    public string? Subject { get; set; }

    public DateTime UpdatedAt { get; set; }
}
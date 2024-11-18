using Scheduling.Infrastructure;

namespace Scheduling.APIs;

public class MeetingsService : MeetingsServiceBase
{
    public MeetingsService(SchedulingDbContext context)
        : base(context) { }
}

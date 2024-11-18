using Microsoft.AspNetCore.Mvc;

namespace Scheduling.APIs;

[ApiController()]
public class MeetingsController : MeetingsControllerBase
{
    public MeetingsController(IMeetingsService service)
        : base(service) { }
}

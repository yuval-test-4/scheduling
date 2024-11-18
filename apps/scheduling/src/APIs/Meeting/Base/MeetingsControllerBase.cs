using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scheduling.APIs;
using Scheduling.APIs.Common;
using Scheduling.APIs.Dtos;
using Scheduling.APIs.Errors;

namespace Scheduling.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MeetingsControllerBase : ControllerBase
{
    protected readonly IMeetingsService _service;

    public MeetingsControllerBase(IMeetingsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one meeting
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Meeting>> CreateMeeting(MeetingCreateInput input)
    {
        var meeting = await _service.CreateMeeting(input);

        return CreatedAtAction(nameof(Meeting), new { id = meeting.Id }, meeting);
    }

    /// <summary>
    /// Delete one meeting
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteMeeting([FromRoute()] MeetingWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteMeeting(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many meetings
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Meeting>>> Meetings(
        [FromQuery()] MeetingFindManyArgs filter
    )
    {
        return Ok(await _service.Meetings(filter));
    }

    /// <summary>
    /// Meta data about meeting records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MeetingsMeta(
        [FromQuery()] MeetingFindManyArgs filter
    )
    {
        return Ok(await _service.MeetingsMeta(filter));
    }

    /// <summary>
    /// Get one meeting
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Meeting>> Meeting([FromRoute()] MeetingWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Meeting(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one meeting
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateMeeting(
        [FromRoute()] MeetingWhereUniqueInput uniqueId,
        [FromQuery()] MeetingUpdateInput meetingUpdateDto
    )
    {
        try
        {
            await _service.UpdateMeeting(uniqueId, meetingUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

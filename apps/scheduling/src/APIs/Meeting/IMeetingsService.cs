using Scheduling.APIs.Common;
using Scheduling.APIs.Dtos;

namespace Scheduling.APIs;

public interface IMeetingsService
{
    /// <summary>
    /// Create one meeting
    /// </summary>
    public Task<Meeting> CreateMeeting(MeetingCreateInput meeting);

    /// <summary>
    /// Delete one meeting
    /// </summary>
    public Task DeleteMeeting(MeetingWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many meetings
    /// </summary>
    public Task<List<Meeting>> Meetings(MeetingFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about meeting records
    /// </summary>
    public Task<MetadataDto> MeetingsMeta(MeetingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one meeting
    /// </summary>
    public Task<Meeting> Meeting(MeetingWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one meeting
    /// </summary>
    public Task UpdateMeeting(MeetingWhereUniqueInput uniqueId, MeetingUpdateInput updateDto);
}

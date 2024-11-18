using Microsoft.EntityFrameworkCore;
using Scheduling.APIs;
using Scheduling.APIs.Common;
using Scheduling.APIs.Dtos;
using Scheduling.APIs.Errors;
using Scheduling.APIs.Extensions;
using Scheduling.Infrastructure;
using Scheduling.Infrastructure.Models;

namespace Scheduling.APIs;

public abstract class MeetingsServiceBase : IMeetingsService
{
    protected readonly SchedulingDbContext _context;

    public MeetingsServiceBase(SchedulingDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one meeting
    /// </summary>
    public async Task<Meeting> CreateMeeting(MeetingCreateInput createDto)
    {
        var meeting = new MeetingDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Date = createDto.Date,
            Subject = createDto.Subject,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            meeting.Id = createDto.Id;
        }

        _context.Meetings.Add(meeting);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<MeetingDbModel>(meeting.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one meeting
    /// </summary>
    public async Task DeleteMeeting(MeetingWhereUniqueInput uniqueId)
    {
        var meeting = await _context.Meetings.FindAsync(uniqueId.Id);
        if (meeting == null)
        {
            throw new NotFoundException();
        }

        _context.Meetings.Remove(meeting);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many meetings
    /// </summary>
    public async Task<List<Meeting>> Meetings(MeetingFindManyArgs findManyArgs)
    {
        var meetings = await _context
            .Meetings.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return meetings.ConvertAll(meeting => meeting.ToDto());
    }

    /// <summary>
    /// Meta data about meeting records
    /// </summary>
    public async Task<MetadataDto> MeetingsMeta(MeetingFindManyArgs findManyArgs)
    {
        var count = await _context.Meetings.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one meeting
    /// </summary>
    public async Task<Meeting> Meeting(MeetingWhereUniqueInput uniqueId)
    {
        var meetings = await this.Meetings(
            new MeetingFindManyArgs { Where = new MeetingWhereInput { Id = uniqueId.Id } }
        );
        var meeting = meetings.FirstOrDefault();
        if (meeting == null)
        {
            throw new NotFoundException();
        }

        return meeting;
    }

    /// <summary>
    /// Update one meeting
    /// </summary>
    public async Task UpdateMeeting(MeetingWhereUniqueInput uniqueId, MeetingUpdateInput updateDto)
    {
        var meeting = updateDto.ToModel(uniqueId);

        _context.Entry(meeting).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Meetings.Any(e => e.Id == meeting.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}

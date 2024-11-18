using Scheduling.APIs.Dtos;
using Scheduling.Infrastructure.Models;

namespace Scheduling.APIs.Extensions;

public static class MeetingsExtensions
{
    public static Meeting ToDto(this MeetingDbModel model)
    {
        return new Meeting
        {
            CreatedAt = model.CreatedAt,
            Date = model.Date,
            Id = model.Id,
            Subject = model.Subject,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static MeetingDbModel ToModel(
        this MeetingUpdateInput updateDto,
        MeetingWhereUniqueInput uniqueId
    )
    {
        var meeting = new MeetingDbModel
        {
            Id = uniqueId.Id,
            Date = updateDto.Date,
            Subject = updateDto.Subject
        };

        if (updateDto.CreatedAt != null)
        {
            meeting.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            meeting.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return meeting;
    }
}

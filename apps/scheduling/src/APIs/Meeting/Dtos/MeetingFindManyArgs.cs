using Microsoft.AspNetCore.Mvc;
using Scheduling.APIs.Common;
using Scheduling.Infrastructure.Models;

namespace Scheduling.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class MeetingFindManyArgs : FindManyInput<Meeting, MeetingWhereInput> { }

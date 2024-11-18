using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scheduling.Infrastructure.Models;

namespace Scheduling.Infrastructure;

public class SchedulingDbContext : IdentityDbContext<IdentityUser>
{
    public SchedulingDbContext(DbContextOptions<SchedulingDbContext> options)
        : base(options) { }

    public DbSet<MeetingDbModel> Meetings { get; set; }
}

using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF;

public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Statistics> Statistics { get; set; }
    public DbSet<Subject> Subjects { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}
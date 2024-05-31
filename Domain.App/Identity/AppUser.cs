using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity;

public class AppUser : IdentityUser<Guid>
    ,IDomainEntityId
{
    // [MinLength(1)]
    // [MaxLength(64)]
    // public string FirstName { get; set; } = default!;
    //
    // [MinLength(1)]
    // [MaxLength(64)]
    // public string LastName { get; set; } = default!;
    
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<Grade> Grades { get; set; }

}
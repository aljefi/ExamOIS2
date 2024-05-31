using Domain.App.Identity;
using Domain.Base;
using Domain.Contracts.Base;

namespace Domain.App;

public class Enrollment : BaseEntityId, IDomainAppUser<AppUser>
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }
    
    public int Semester { get; set; }
}
using Domain.App.Identity;
using Domain.Base;
using Domain.Contracts.Base;

namespace Domain.App;

public class Grade : BaseEntityId, IDomainAppUser<AppUser>
{
    
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    
    public Guid AssignmentId { get; set; }
    public Assignment? Assignment { get; set; }
    
    private DateTime _dateGiven;

    public DateTime DateGiven
    {
        get => _dateGiven;
        set => _dateGiven = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    public int GradeValue { get; set; }
}
using Domain.Base;

namespace Domain.App;

public class Assignment : BaseEntityId
{
    public Guid SubjectId { get; set; }
    public Subject? Subject { get; set; }

    public ICollection<Grade>? Grades { get; set; }
}
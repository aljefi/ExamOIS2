using Domain.Base;

namespace Domain.App;

public class Subject : BaseEntityId
{
    public string SubjectName { get; set; }


    public ICollection<Statistics>? Statistics { get; set; }
    public ICollection<Assignment>? Assignments { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; }
}
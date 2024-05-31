using Domain.Base;

namespace Domain.App;

public class Statistics : BaseEntityId
{
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }

    public float AverageGrade { get; set; }
}
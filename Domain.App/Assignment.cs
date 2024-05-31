using Domain.Base;

namespace Domain.App;

public class Assignment : BaseEntityId
{
    public Guid SubjectId { get; set; }
    public Subject? Subject { get; set; }

    public string Title { get; set; }
    
    private DateTime _dueDate;

    public DateTime DueDate
    {
        get => _dueDate;
        set => _dueDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    public ICollection<Grade>? Grades { get; set; }
}
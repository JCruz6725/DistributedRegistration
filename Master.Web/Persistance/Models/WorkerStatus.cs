namespace Master.Web.Persistance.Models;

public partial class WorkerStatus
{
    public Guid Id { get; set; }

    public Guid WorkerId { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid StatusId { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual Worker Worker { get; set; } = null!;
}

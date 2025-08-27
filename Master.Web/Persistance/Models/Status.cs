namespace Master.Web.Persistance.Models;

public partial class Status
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Code { get; set; }

    public virtual ICollection<WorkerStatus> WorkerStatuses { get; set; } = new List<WorkerStatus>();
}

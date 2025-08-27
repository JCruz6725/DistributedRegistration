namespace Master.Web.Persistance.Models;

public partial class Worker
{
    public Guid Id { get; set; }

    public DateTime RegistrationDate { get; set; }

    public virtual ICollection<WorkerStatus> WorkerStatuses { get; set; } = new List<WorkerStatus>();
}

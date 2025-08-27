namespace Master.Web.Persistance.Models;

public partial class GetLatestWorkerStatus
{
    public string Name { get; set; } = null!;

    public int Code { get; set; }

    public Guid WorkerId { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid StatusId { get; set; }
}

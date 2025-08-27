using Master.Web.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace Master.Web.Persistance;

public partial class RegistrationDbContext : DbContext
{
    public RegistrationDbContext()
    {
    }

    public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GetLatestWorkerStatus> GetLatestWorkerStatuses { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Models.Worker> Workers { get; set; }

    public virtual DbSet<WorkerStatus> WorkerStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GetLatestWorkerStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetLatestWorkerStatus");

            entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasIndex(e => e.Code, "IX_Statuses");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Models.Worker>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RegistrationDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<WorkerStatus>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

            entity.HasOne(d => d.Status).WithMany(p => p.WorkerStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkerStatuses_Statuses");

            entity.HasOne(d => d.Worker).WithMany(p => p.WorkerStatuses)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkerStatuses_Workers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

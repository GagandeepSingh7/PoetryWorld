using Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Data;

public partial class LoginPageContext : DbContext
{
    public LoginPageContext()
    {
    }

    public LoginPageContext(DbContextOptions<LoginPageContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Human> Humans { get; set; }
    public virtual DbSet<EmailDto> Dto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(
            "Server=Gagan; Trusted_Connection=True; Initial Catalog=LoginPage; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRegister>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("UserRegister");

            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
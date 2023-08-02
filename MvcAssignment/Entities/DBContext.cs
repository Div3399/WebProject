using Microsoft.EntityFrameworkCore;


namespace MvcAssignment.Entities
{
    public partial class DBContext:DbContext
    {
         public DBContext()
        {

        }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public virtual DbSet<Patientdetail> Patientdetails { get; set; }
        public virtual DbSet<Clinicdetail> Clinicdetails { get; set; }
        public virtual DbSet<Doctordetail> Doctordetails { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        partial void OnModelCreatingl(ModelBuilder modelBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patientdetail>(entity => { entity.ToTable("PatientMaster"); });
            modelBuilder.Entity<Clinicdetail>(entity => { entity.ToTable("tbl_ClinicDetails"); });
            modelBuilder.Entity<Doctordetail>(entity => { entity.ToTable("tbl_DoctorDetails"); });

            OnModelCreatingPartial(modelBuilder);

        }
    }
}

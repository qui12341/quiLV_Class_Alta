using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Roles> role { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Classes> classes { get; set; }
        public DbSet<Student> student { get; set; }
        public DbSet<Student_Class> student_Classes { get;set; }
        public DbSet<Point_Class> point_Classes { get; set; }
        public DbSet<Point_Type> point_types { get; set; }
        public DbSet<Point> points { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Nest_Department> nest_Departments { get; set; }
        public DbSet<Revenue> revenue { get; set; }
        public DbSet<Teacher> teacher { get; set; }
        public DbSet<Teacher_CLass> teacher_CLasses { get; set; }
        public DbSet<Holiday_schedule> holiday_Schedules { get; set; }
        public DbSet<Subject_Class> subject_Classes { get; set; }
        public DbSet<Calendar> calendars { get; set; }
        public DbSet<Wage> wages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student_Class>()
            .HasOne<Student>()
            .WithMany()
            .HasForeignKey(sc => sc.Student_Id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student_Class>()
            .HasOne<Classes>()
            .WithMany()
            .HasForeignKey(sc => sc.Class_Id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
            .HasOne<Roles>()
            .WithMany()
            .HasForeignKey(u => u.Role_ID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.User_ID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Point_Class>()
            .HasOne<Point>()
            .WithMany()
            .HasForeignKey(pc => pc.Point_ID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Point_Class>()
            .HasOne<Classes>()
            .WithMany()
            .HasForeignKey(pc => pc.Class_Id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Point>()
            .HasOne<Subject>()
            .WithMany()
            .HasForeignKey(p => p.Subject_ID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Point>()
            .HasOne<Course>()
            .WithMany()
            .HasForeignKey(p => p.Course_ID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Point>()
            .HasOne<Point_Type>()
            .WithMany()
            .HasForeignKey(p => p.Point_Type_ID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subject>()
            .HasOne<Nest_Department>()
            .WithMany()
            .HasForeignKey(s => s.Nest_Department_Id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Revenue>()
            .HasOne<Classes>()
            .WithMany()
            .HasForeignKey(r => r.Class_Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teacher_CLass>()
            .HasOne<Teacher>()
            .WithMany()
            .HasForeignKey(tc => tc.Teacher_Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teacher_CLass>()
            .HasOne<Classes>()
            .WithMany()
            .HasForeignKey(tc => tc.Class_Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Calendar>()
            .HasOne<Classes>()
            .WithMany()
            .HasForeignKey(c => c.Class_Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Calendar>()
            .HasOne<Teacher>()
            .WithMany()
            .HasForeignKey(c => c.Teacher_Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Calendar>()
            .HasOne<Subject>()
            .WithMany()
            .HasForeignKey(c => c.Subject_ID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subject_Class>()
            .HasOne<Subject>()
            .WithMany()
            .HasForeignKey(sc => sc.Subject_ID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subject_Class>()
            .HasOne<Classes>()
            .WithMany()
            .HasForeignKey(sc => sc.Class_Id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Wage>()
            .HasOne<Teacher>()
            .WithMany()
            .HasForeignKey(w => w.Teacher_Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teacher>()
            .HasOne<Nest_Department>()
            .WithMany()
            .HasForeignKey(t => t.Nest_Department_Id)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

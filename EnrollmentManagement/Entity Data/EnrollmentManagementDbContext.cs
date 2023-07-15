using EnrollmentManagement.Identity_Application;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentManagement.Entity_Data
{
    public class EnrollmentManagementDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public EnrollmentManagementDbContext(DbContextOptions<EnrollmentManagementDbContext> options) : base(options) 
        {
            
        }
        #region DataSet
        public DbSet<Classes>? Classes { get; set; } 
        public DbSet<ClassStudent>? ClassStudents { get; set; }
        public DbSet<Courses>? Courses { get; set; }
        public DbSet<Departments>? Departments { get; set; }
        public DbSet<Grades>? Grades { get; set; }
        public DbSet<Points>? Points { get; set; }
        public DbSet<Registrations>? Registrations { get; set; }
        public DbSet<Rooms>? Rooms { get; set; }
        public DbSet<Schedules>? Schedules { get; set; }
        public DbSet<Students>? Students { get; set; }
        public DbSet<Subjects>? Subjects { get; set; }
        public DbSet<SubjectTeacher>? SubjectTeachers { get; set; }
        public DbSet<Teachers>? Teachers { get; set; }
        public DbSet<Tuitions>? Tuitions { get; set; }
        public DbSet<TypePoints>? TypePoints { get; set; }
        public DbSet<TypePointsGrade>? TypePointsGrades { get; set; }
        public DbSet<VacationSchedule>? VacationSchedules { get; set; }
        public DbSet<Weekdays>? Weekdays { get; set; }
        public DbSet<Permissions>? Permissions { get; set; }
        public DbSet<PermissionRole>? PermissionRole { get; set; }
        #endregion
    }
}

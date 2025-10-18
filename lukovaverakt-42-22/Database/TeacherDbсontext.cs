using Microsoft.EntityFrameworkCore;
using lukovaverakt_42_22.Controllers;
using lukovaverakt_42_22.Database.Configurations;
using lukovaverakt_42_22.Models;

namespace lukovaverakt_42_22
{
    public class TeacherDbсontext : DbContext
    {
        //Добавляем таблицы
        DbSet<Teacher> Teacher { get; set; }
        DbSet<AcademicDegree> AcademicDegree { get; set; }
        DbSet<JobPosition> JobPosition { get; set; }
        DbSet<Department> Department { get; set; }
        DbSet<Disciplines> Discipline { get; set; }
        DbSet<WorkLoad> WorkLoad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new WorkLoadConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new JobPositionConfiguration());
        }
        public TeacherDbсontext(DbContextOptions<TeacherDbсontext> options) : base(options)
        {

        }
    }
}

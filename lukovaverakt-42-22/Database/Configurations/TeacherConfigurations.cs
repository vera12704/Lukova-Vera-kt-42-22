using lukovaverakt_42_22.Database.Helpers;
using lukovaverakt_42_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lukovaverakt_42_22.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.TeacherId)
                .HasName($"pk_{TableName}_teacher_id");

            //Для целочисленного первичного ключа задаем автогенерацию
            builder.Property(p => p.TeacherId)
                .ValueGeneratedOnAdd();

            //Расписываем, как будут называться колонки в БД, а также их обязательность
            builder.Property(p => p.TeacherId)
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор записи преподавателя");

            builder.Property(p => p.FirstName)
            .IsRequired()
            .HasColumnName("c_teacher_firstname")
            .HasColumnType(ColumnType.String).HasMaxLength(100)
            .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_teacher_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.MiddleName)
                .HasColumnName("c_teacher_middlename")
                .HasComment("Отчество");

            builder.ToTable(TableName)
                .HasOne(p => p.AcademicDegree)
                .WithMany()
                .HasForeignKey(p => p.AcademicDegreeId)
                .HasConstraintName("fk_f_academic_degree_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.AcademicDegreeId, $"idx_{TableName}_fk_f_academic_degree_id");

            //Добавляем новую автоподгрузку связанной сущности
            builder.Navigation(p => p.AcademicDegree)
                .AutoInclude();

            //Для JobPosition
            builder.ToTable(TableName)
              .HasOne(p => p.JobPosition)
              .WithMany()
              .HasForeignKey(p => p.JobPositionId)
              .HasConstraintName("fk_f_job_position_id")
              .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.AcademicDegreeId, $"idx_{TableName}_fk_f_job_position_id");

            //Добавляем новую автоподгрузку связанной сущности
            builder.Navigation(p => p.JobPosition)
                .AutoInclude();

            //Для Department
            builder.ToTable(TableName)
               .HasOne(p => p.Department)
               .WithMany()
               .HasForeignKey(p => p.DepartmentId)
               .HasConstraintName("fk_f_department_id")
               .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.AcademicDegreeId, $"idx_{TableName}_fk_f_department_id");

            //Добавляем новую автоподгрузку связанной сущности
            builder.Navigation(p => p.Department)
                .AutoInclude();

        }
    }

}

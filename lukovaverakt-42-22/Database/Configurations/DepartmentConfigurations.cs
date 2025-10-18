
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;
using lukovaverakt_42_22.Models;
using lukovaverakt_42_22.Database.Helpers;

namespace lukovaverakt_42_22.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cd_department";
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //Задаем первичный ключ
            builder
            .HasKey(p => p.DepartmentId)
                .HasName($"pk_{TableName}_department_id");

            //Для целочисленного первичного ключа задаем автогенерацию
            builder.Property(p => p.DepartmentId)
                .ValueGeneratedOnAdd();

            //Расписываем, как будут называться колонки в БД, а также их обязательность
            builder.Property(p => p.DepartmentId)
                .HasColumnName("group_id")
                .HasComment("Идентификатор записи кафедры");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("c_department_name")
            .HasColumnType(ColumnType.String).HasMaxLength(100)
            .HasComment("Наименование кафедры");

            //для LeaderId
            builder.ToTable(TableName)
               .HasOne(p => p.Teacher)
               .WithOne()
               .HasForeignKey<Department>(p => p.TeacherId)
               .HasConstraintName("fk_leader_id")
               .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(TableName)
                .HasIndex(p => p.TeacherId, $"idx_{TableName}_fk_f_teacher_id");

            //Добавляем новую автоподгрузку связанной сущности
            builder.Navigation(p => p.Teacher)
                .AutoInclude();
        }
    }
}


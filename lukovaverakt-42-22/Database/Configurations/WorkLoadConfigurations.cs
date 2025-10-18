using lukovaverakt_42_22.Database.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using lukovaverakt_42_22.Models;
namespace lukovaverakt_42_22.Database.Configurations
{
    public class WorkLoadConfiguration : IEntityTypeConfiguration<WorkLoad>
    {
        private const string TableName = "cd_work_load";
        public void Configure(EntityTypeBuilder<WorkLoad> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.WorkLoadId)
                .HasName($"pk_{TableName}_work_load_id");

            //Для целочисленного первичного ключа задаем автогенерацию
            builder.Property(p => p.WorkLoadId)
                .ValueGeneratedOnAdd();

            //Расписываем, как будут называться колонки в БД, а также их обязательность
            builder.Property(p => p.WorkLoadId)
                .HasColumnName("work_load_id")
                .HasComment("Идентификатор записи рабочей программы");

            builder.Property(p => p.Hours)
            .HasColumnName("c_hours")
            .HasColumnType(ColumnType.Int)
            .HasComment("количество часов");

            builder.ToTable(TableName)
                .HasOne(p => p.Teacher)
                .WithMany()
                .HasForeignKey(p => p.TeacherId)
                .HasConstraintName("fk_teacher_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.TeacherId, $"idx_{TableName}_fk_f_teacher_id");

            //Для Discipline
            builder.ToTable(TableName)
               .HasOne(p => p.Discipline)
               .WithMany()
               .HasForeignKey(p => p.DisciplineId)
               .HasConstraintName("fk_f_discipline_id")
               .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.TeacherId, $"idx_{TableName}_fk_f_discipline_id");

            //Добавляем новую автоподгрузку связанной сущности
            builder.Navigation(p => p.Discipline)
                .AutoInclude();
        }
    }

}
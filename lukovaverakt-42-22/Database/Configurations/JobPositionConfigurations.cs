using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using lukovaverakt_42_22.Database.Helpers;
using lukovaverakt_42_22.Models;

namespace lukovaverakt_42_22.Database.Configurations
{
    public class JobPositionConfiguration : IEntityTypeConfiguration<JobPosition>
    {
        private const string TableName = "cd_job_position";
        public void Configure(EntityTypeBuilder<JobPosition> builder)
        {
            //Задаем первичный ключ
            builder
            .HasKey(p => p.JobPositionId)
                .HasName($"pk_{TableName}_job_position_id");

            //Для целочисленного первичного ключа задаем автогенерацию
            builder.Property(p => p.JobPositionId)
                .ValueGeneratedOnAdd();

            //Расписываем, как будут называться колонки в БД, а также их обязательность
            builder.Property(p => p.JobPositionId)
                .HasColumnName("job_position_id")
                .HasComment("Идентификатор записи ученой должности преподавателя");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("c_academic_degree_name")
            .HasColumnType(ColumnType.String).HasMaxLength(100)
            .HasComment("Наименование должности");
        }
    }
}


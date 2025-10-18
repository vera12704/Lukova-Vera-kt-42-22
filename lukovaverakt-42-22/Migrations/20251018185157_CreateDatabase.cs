using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lukovaverakt4222.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegree",
                columns: table => new
                {
                    academicdegreeid = table.Column<int>(name: "academic_degree_id", type: "int", nullable: false, comment: "Идентификатор записи ученой степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cacademicdegreename = table.Column<string>(name: "c_academic_degree_name", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Наименование ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academic_degree_academic_degree_id", x => x.academicdegreeid);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    disciplineid = table.Column<int>(name: "discipline_id", type: "int", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cвisciplinename = table.Column<string>(name: "c_вiscipline_name", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Наименование дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_disciplinep_id", x => x.disciplineid);
                });

            migrationBuilder.CreateTable(
                name: "JobPosition",
                columns: table => new
                {
                    jobpositionid = table.Column<int>(name: "job_position_id", type: "int", nullable: false, comment: "Идентификатор записи ученой должности преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cacademicdegreename = table.Column<string>(name: "c_academic_degree_name", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Наименование должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_job_position_job_position_id", x => x.jobpositionid);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    groupid = table.Column<int>(name: "group_id", type: "int", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cdepartmentname = table.Column<string>(name: "c_department_name", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Наименование кафедры"),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.groupid);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacherid = table.Column<int>(name: "teacher_id", type: "int", nullable: false, comment: "Идентификатор записи преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cteacherfirstname = table.Column<string>(name: "c_teacher_firstname", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    cteacherlastname = table.Column<string>(name: "c_teacher_lastname", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    cteachermiddlename = table.Column<string>(name: "c_teacher_middlename", type: "nvarchar(max)", nullable: false, comment: "Отчество"),
                    AcademicDegreeId = table.Column<int>(type: "int", nullable: false),
                    JobPositionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacherid);
                    table.ForeignKey(
                        name: "fk_f_academic_degree_id",
                        column: x => x.AcademicDegreeId,
                        principalTable: "AcademicDegree",
                        principalColumn: "academic_degree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_department_id",
                        column: x => x.DepartmentId,
                        principalTable: "cd_department",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_job_position_id",
                        column: x => x.JobPositionId,
                        principalTable: "JobPosition",
                        principalColumn: "job_position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_work_load",
                columns: table => new
                {
                    workloadid = table.Column<int>(name: "work_load_id", type: "int", nullable: false, comment: "Идентификатор записи рабочей программы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    chours = table.Column<int>(name: "c_hours", type: "int", nullable: false, comment: "количество часов")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_work_load_work_load_id", x => x.workloadid);
                    table.ForeignKey(
                        name: "fk_f_discipline_id",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teacher_id",
                        column: x => x.TeacherId,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_department_fk_f_teacher_id",
                table: "cd_department",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_department_TeacherId",
                table: "cd_department",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_academic_degree_id",
                table: "cd_teacher",
                column: "AcademicDegreeId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_department_id",
                table: "cd_teacher",
                column: "AcademicDegreeId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_job_position_id",
                table: "cd_teacher",
                column: "AcademicDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_DepartmentId",
                table: "cd_teacher",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_JobPositionId",
                table: "cd_teacher",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_work_load_fk_f_discipline_id",
                table: "cd_work_load",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_work_load_fk_f_teacher_id",
                table: "cd_work_load",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_work_load_DisciplineId",
                table: "cd_work_load",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "fk_leader_id",
                table: "cd_department",
                column: "TeacherId",
                principalTable: "cd_teacher",
                principalColumn: "teacher_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_leader_id",
                table: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_work_load");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "AcademicDegree");

            migrationBuilder.DropTable(
                name: "cd_department");

            migrationBuilder.DropTable(
                name: "JobPosition");
        }
    }
}

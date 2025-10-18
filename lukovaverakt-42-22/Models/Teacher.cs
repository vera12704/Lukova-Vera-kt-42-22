namespace lukovaverakt_42_22.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int AcademicDegreeId { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
        public int JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}

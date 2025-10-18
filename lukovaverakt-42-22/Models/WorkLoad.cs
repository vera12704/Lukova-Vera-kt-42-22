namespace lukovaverakt_42_22.Models
{
    public class WorkLoad
    {
        public int WorkLoadId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int DisciplineId { get; set; }
        public Disciplines Discipline { get; set; }
        public int Hours { get; set; }
    }
}

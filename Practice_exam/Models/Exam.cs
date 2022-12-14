namespace Practice_exam.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateOnly ExamDate { get; set; }
        public int Duration { get; set; }
        public string? ClassRoom { get; set; }
        public string? Faculty { get; set; }
        public string? Status { get; set; } 
    }
}

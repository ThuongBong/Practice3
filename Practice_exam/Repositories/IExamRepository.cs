using Practice_exam.Models;

namespace Practice_exam.Repositories
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetExamp();
        Task<Exam> GetExam(int? id);
        Task CreateExam(Exam company);
    }
}

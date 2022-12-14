using Dapper;
using Practice_exam.DBContext;
using Practice_exam.Models;
using System.Data;

namespace Practice_exam.Repositories
{
    public class ExamRepository : IExamRepository

    {
        private readonly DapperContext context;

        public ExamRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Exam>> GetExamp()
        {
            var query = "SELECT * FROM exam";

            using (var connection = context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Exam>(query);
                return companies.ToList();
            }
        }

        public async Task<Exam> GetExam(int? id)
        {
            var query = "SELECT * FROM exam WHERE Id = @Id";

            using (var connection = context.CreateConnection())
            {
                var exam = await connection.QuerySingleOrDefaultAsync<Exam>(query, new { id });
                return exam;
            }
        }

        public async Task CreateExam(Exam exam)
        {
            var query = "INSERT INTO exam (Subject, StartTime, ExamDate,Duration, ClassRoom, Faculty, Status) VALUES (@Subject, @StartTime, @ExamDate, @Duration, @ClassRoom, @Faculty, @Status)";

            var parameters = new DynamicParameters();
            parameters.Add("Subject", exam.Subject, DbType.String);
            parameters.Add("Time", exam.StartTime, DbType.Time);
            parameters.Add("Date", exam.ExamDate, DbType.Date);
            parameters.Add("Duration", exam.Duration, DbType.Int32);
            parameters.Add("ClassRoom", exam.ClassRoom, DbType.String);
            parameters.Add("Faculty", exam.Faculty, DbType.String);
            parameters.Add("Status", exam.Status, DbType.String);

            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

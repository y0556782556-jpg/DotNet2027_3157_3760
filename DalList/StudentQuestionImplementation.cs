using Dal;
using DalApi;
using DO;

namespace DalList
{
    internal class StudentQuestionImplementation : IStudentQuestion
    {
        public int Create(StudentQuestion item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            
            throw new Exception("not to delete");
        }

        public StudentQuestion? Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<StudentQuestion?> ReadAll()
        {
            return new List<StudentQuestion?>(DataSource.StudentQuestions);
        }

        public void Update(StudentQuestion item)
        {
            throw new NotImplementedException();
        }
    }
}
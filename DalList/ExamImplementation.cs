using Dal;
using DalApi;
using DO;

namespace DalList
{
    internal class ExamImplementation : IExam
    {
        public int Create(Exam item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new Exception("not to delete");
        }

        public Exam? Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<Exam?> ReadAll()
        {
            return new List<Exam?>(DataSource.Exams);
        }

        public void Update(Exam item)
        {
            throw new NotImplementedException();
        }
    }
}
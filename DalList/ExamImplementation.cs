
using DalApi;
using DO;

namespace Dal
{
    internal class ExamImplementation : IExam
    {
        public int Create(Exam item)
        {
            int id=DataSource.Config.ExamId;
            Exam newExam=item with { ExamId=id };
            DataSource.Exams.Add(newExam);
            return id;


        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Exam? Read(int id)
        {
            return DataSource.Exams.FirstOrDefault(
            x => x != null && x.ExamId == id);

        }

        public List<Exam> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Exam item)
        {
            for (int i = 0; i < DataSource.Exams.Count; i++)
            {
                if (DataSource.Exams[i]?.ExamId == item.ExamId)
                {
                    DataSource.Exams.RemoveAt(i);
                    DataSource.Exams.Add(item);
                    return;

                }

            }
            throw new Exception($"Exam with ID {item.ExamId} does not exist");

        }
    }
}

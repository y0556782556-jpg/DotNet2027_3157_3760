using Dal;
using DalApi;
using DO;

namespace DalList
{
    internal class StudentQuestionImplementation : IStudentQuestion
    {
        public int Create(StudentQuestion item)
        {
           int id=DataSource.Config.StudentQuestionId;
            StudentQuestion studentQuestion = item with { StudentQuestionId = id };
            DataSource.StudentQuestions.Add(studentQuestion);
            return id;
        }

        public void Delete(int id)
        {
            
            throw new Exception("not to delete");
        }

        public StudentQuestion? Read(int id)
        {
            return DataSource.StudentQuestions.FirstOrDefault(
      x => x != null && x.StudentQuestionId == id);
        }

        public List<StudentQuestion?> ReadAll()
        {
            return new List<StudentQuestion?>(DataSource.StudentQuestions);
        }

        public void Update(StudentQuestion item)
        {
            for (int i = 0; i < DataSource.StudentQuestions.Count; i++)
            {
                if (DataSource.StudentQuestions[i]?.StudentQuestionId == item.StudentQuestionId)
                {
                    DataSource.StudentQuestions.RemoveAt(i);
                    DataSource.StudentQuestions.Add(item);
                    return;

                }

            }
            throw new Exception($"StudentQuestion with ID {item.StudentQuestionId} does not exist");

        }
    }
}
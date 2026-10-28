using Dal;
using DalApi;
using DO;
using System.Runtime.InteropServices;

namespace DalList
{
    internal class QuestionImplementation : IQuestion
    {
        public int Create(Question item)
        {
            int id=DataSource.Config.QuestionId;
            Question question = item with { QuestionId = id };
            DataSource.Questions.Add(question);
            return id;
        }

        public void Delete(int id)
        {
            bool flag = false;
            for (int i = 0; i < DataSource.Questions.Count; i++)
            {
                if (DataSource.Questions[i]?.questionId == id)
                {
                    DataSource.Questions.Remove(DataSource.Questions[i]);
                    flag = true;
                    break;
                }
            }
            if (!flag)
                throw new NotExistsExceptions("The id not found");
        }

        public Question? Read(int id)
        {
             return DataSource.Questions.FirstOrDefault(
            x => x != null && x.QuestionId == id);
        }

        public List<Question?> ReadAll()
        {
            return new List<Question?>(DataSource.Questions);
        }

        public void Update(Question item)
        {
            for (int i = 0; i < DataSource.Questions.Count; i++)
            {
                if (DataSource.Questions[i]?.QuestionId == item.QuestionId)
                {
                    DataSource.Questions.RemoveAt(i);
                    DataSource.Questions.Add(item);
                    return;

                }

            }
            throw new Exception($"Question with ID {item.QuestionId} does not exist");
        }
    }
}
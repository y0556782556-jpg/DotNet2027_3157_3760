using Dal;
using DalApi;
using DO;

namespace Dal
{
    internal class AnswerImplementation : IAnswer
    {
        public int Create(Answer item)
        {
            int id = DataSource.Config.AnswerId;
            Answer answer = item with { AnswerId = id };
            DataSource.Answers.Add(answer);
            return id;

        }

        public void Delete(int id)
        {
            bool flag = false;
            for (int i = 0; i < DataSource.Answers.Count; i++)
            {
                if (DataSource.Answers[i]?.AnswerId == id)
                {
                    DataSource.Answers.Remove(DataSource.Answers[i]);
                    flag = true;
                    break;
                }
            }
            if (!flag)
                throw new NotExistsExceptions("The id not found");
        }

        public Answer? Read(int id)
        {
            return DataSource.Answers.FirstOrDefault(
                 x => x != null && x.AnswerId == id);
        }

        public List<Answer> ReadAll()
        {
            return new List<Answer?>(DataSource.Answers);
        }

        public void Update(Answer item)
        {

            for (int i = 0; i < DataSource.Answers.Count; i++)
            {
                if (DataSource.Answers[i]?.AnswerId == item.AnswerId)
                {
                    DataSource.Answers.RemoveAt(i);
                    DataSource.Answers.Add(item);
                    return;

                }

            }
            throw new Exception($"Answer with ID {item.AnswerId} does not exist");

        }
    }
}

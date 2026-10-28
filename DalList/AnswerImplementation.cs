using Dal;
using DalApi;
using DO;

namespace DalList
{
    internal class AnswerImplementation : IAnswer
    {
        public int Create(Answer item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            bool flag = false;
            for (int i = 0; i < DataSource.Answers.Count; i++)
            {
                if (DataSource.Answers[i]?.answerId == id)
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
            throw new NotImplementedException();
        }

        public List<Answer?> ReadAll()
        {
            return new List<Answer?>(DataSource.Answers);
        }

        public void Update(Answer item)
        {
            throw new NotImplementedException();
        }
    }
}
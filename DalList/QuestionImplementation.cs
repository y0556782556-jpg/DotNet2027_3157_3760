using Dal;
using DalApi;
using DO;

namespace DalList
{
    internal class QuestionImplementation : IQuestion
    {
        public int Create(Question item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<Question?> ReadAll()
        {
            return new List<Question?>(DataSource.Questions);
        }

        public void Update(Question item)
        {
            throw new NotImplementedException();
        }
    }
}
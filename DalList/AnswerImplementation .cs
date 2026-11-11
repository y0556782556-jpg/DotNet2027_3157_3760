using Dal;
using DalApi;
using DO;

using System.Reflection;
using Tools;

namespace Dal
{
    internal class AnswerImplementation : IAnswer
    {
        public int Create(Answer item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
                MethodBase.GetCurrentMethod().DeclaringType.FullName,
                "Start creating answer");

            int id = DataSource.Config.AnswerId;
            Answer answer = item with { AnswerId = id };
            DataSource.Answers.Add(answer);

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
            MethodBase.GetCurrentMethod().DeclaringType.FullName,
                   $"Answer created successfully with ID: {id}");
            return id;

        }

        public void Delete(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
             MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Start deleting Answer");

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
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
$"Error,id:{id} not found");
                throw new NotExistsExceptions("The id not found");

            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
            MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Answer deleted successfully");

        }

        public Answer? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
           MethodBase.GetCurrentMethod().DeclaringType.FullName,
           "Start reading Answer");

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
             MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Finished reading Answer");
            return DataSource.Answers.FirstOrDefault(
                 x => x != null && x.AnswerId == id);
        }

        public List<Answer> ReadAll()
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start reading all Answers");

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
             MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Finished reading all Answers");
            return new List<Answer?>(DataSource.Answers);
        }

        public void Update(Answer item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start updating Answer");
            for (int i = 0; i < DataSource.Answers.Count; i++)
            {
                if (DataSource.Answers[i]?.AnswerId == item.AnswerId)
                {
                    DataSource.Answers.RemoveAt(i);
                    DataSource.Answers.Add(item);

                    LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Answer updated successfully");
                    return;

                }

            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
$"Error,id:{item.AnswerId} not found");
            throw new Exception($"Answer with ID {item.AnswerId} does not exist");


        }
    }
}

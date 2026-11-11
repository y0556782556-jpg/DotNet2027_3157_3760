using Dal;
using DalApi;
using DO;
using System.Reflection;
using System.Runtime.InteropServices;
using Tools;

namespace DalList
{
    internal class QuestionImplementation : IQuestion
    {
        public int Create(Question item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
            MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Start creating question");

            int id=DataSource.Config.QuestionId;
            Question question = item with { QuestionId = id };
            DataSource.Questions.Add(question);

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
            MethodBase.GetCurrentMethod().DeclaringType.FullName,
            $"Question created successfully with ID: {id}");


            return id;

        }

        public void Delete(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
            MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Start deleting Question");
            bool flag = false;
            for (int i = 0; i < DataSource.Questions.Count; i++)
            {
                if (DataSource.Questions[i]?.QuestionId == id)
                {
                    DataSource.Questions.Remove(DataSource.Questions[i]);
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                throw new NotExistsExceptions("The id not found");
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
$"Error,id:{id} not found");
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Question deleted successfully");
            throw new NotExistsExceptions("The id not found");


        }

        public Question? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start reading Question");
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
             MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Finished reading Question");
            return DataSource.Questions.FirstOrDefault(
            x => x != null && x.QuestionId == id);
        }

        public List<Question?> ReadAll()
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start reading all Questions");

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
             MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Finished reading all Questions");

            return new List<Question?>(DataSource.Questions);
        }

        public void Update(Question item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start updating Question");
            for (int i = 0; i < DataSource.Questions.Count; i++)
            {
                if (DataSource.Questions[i]?.QuestionId == item.QuestionId)
                {
                    DataSource.Questions.RemoveAt(i);
                    DataSource.Questions.Add(item);
                    LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Question updated successfully");
                    return;

                }

            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
$"Error,id:{item.QuestionId} not found");
            throw new Exception($"Question with ID {item.QuestionId} does not exist");

        }
    }
}
using Dal;
using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace DalList
{
    internal class StudentQuestionImplementation : IStudentQuestion
    {
        public int Create(StudentQuestion item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
            MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Start creating studentQuestion");


            int id=DataSource.Config.StudentQuestionId;
            StudentQuestion studentQuestion = item with { StudentQuestionId = id };
            DataSource.StudentQuestions.Add(studentQuestion);

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
            MethodBase.GetCurrentMethod().DeclaringType.FullName,
            $"StudentQuestion created successfully with ID: {id}");


            return id;
        }

        public void Delete(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
$"Error,not to delete");
            throw new Exception("not to delete");
        }

        public StudentQuestion? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
            MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Start reading StudentQuestion");
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
             MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Finished reading StudentQuestion");

            return DataSource.StudentQuestions.FirstOrDefault(
      x => x != null && x.StudentQuestionId == id);
        }

        public List<StudentQuestion?> ReadAll()
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start reading all StudentQuestions");

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
             MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Finished reading all StudentQuestions");

            return new List<StudentQuestion?>(DataSource.StudentQuestions);
        }

        public void Update(StudentQuestion item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start updating StudentQuestion");
            for (int i = 0; i < DataSource.StudentQuestions.Count; i++)
            {
                if (DataSource.StudentQuestions[i]?.StudentQuestionId == item.StudentQuestionId)
                {
                    DataSource.StudentQuestions.RemoveAt(i);
                    DataSource.StudentQuestions.Add(item);
                    LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"StudentQuestion updated successfully");
                    return;

                }

            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
$"Error,id:{item.StudentQuestionId} not found");
            throw new Exception($"StudentQuestion with ID {item.StudentQuestionId} does not exist");

        }
    }
}
using Dal;
using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace DalList
{
    internal class ExamImplementation : IExam
    {
        public int Create(Exam item)
        {
               LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
               MethodBase.GetCurrentMethod().DeclaringType.FullName,
              "Start creating exam");

            int id=DataSource.Config.ExamId;
            Exam newExam=item with { ExamId=id };
            DataSource.Exams.Add(newExam);

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
             MethodBase.GetCurrentMethod().DeclaringType.FullName,
            $"Exan created successfully with ID: {id}");
            return id;



        }

        public void Delete(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
 MethodBase.GetCurrentMethod().DeclaringType.FullName,
$"Error,not to delete");
            throw new Exception("not to delete");
        }

        public Exam? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start reading Exam");

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
             MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Finished reading Exam");
            return DataSource.Exams.FirstOrDefault(
            x => x != null && x.ExamId == id);

        }

        public List<Exam?> ReadAll()
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start reading all Exams");

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
             MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Finished reading all Exams");
            return new List<Exam?>(DataSource.Exams);
        }

        public void Update(Exam item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start updating Exam");
            for (int i = 0; i < DataSource.Exams.Count; i++)
            {
                if (DataSource.Exams[i]?.ExamId == item.ExamId)
                {
                    DataSource.Exams.RemoveAt(i);
                    DataSource.Exams.Add(item);
                    LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Exam updated successfully");
                    return;

                }

            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
$"Error,id:{item.ExamId} not found");
            throw new Exception($"Exam with ID {item.ExamId} does not exist");

        }
    }
}
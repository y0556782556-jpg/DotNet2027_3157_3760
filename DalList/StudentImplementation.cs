using Dal;
using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace DalList
{
    internal class StudentImplementation : IStudent
    {
        public int Create(Student item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
            MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Start creating student");


            if (DataSource.Students.Any(s => s?.StudentId == item.StudentId))
            {
                throw new Exception($"Student with ID {item.StudentId} already exists");
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
$"Error,student with ID {item.StudentId} already exists");
            }
                DataSource.Students.Add(item);


            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
            MethodBase.GetCurrentMethod().DeclaringType.FullName,
            $"Student created successfully with ID: {item.StudentId}");



            return item.StudentId;
        }

        public void Delete(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
 MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start deleting Student");
            bool flag = false;
            for(int i=0; i< DataSource.Students.Count;i++)
            {
                if (DataSource.Students[i]?.StudentId == id)
                {
                    DataSource.Students.Remove(DataSource.Students[i]);
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
"Student deleted successfully");
            throw new NotExistsExceptions("The id not found");

        }

        public Student? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start reading Student");
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
             MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Finished reading Student");
            return DataSource.Students.FirstOrDefault(
      x => x != null && x.StudentId == id);
        }

        public List<Student?> ReadAll()
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start reading all Students");

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
             MethodBase.GetCurrentMethod().DeclaringType.FullName,
            "Finished reading all Students");

            return new List<Student?>(DataSource.Students);
        }

        public void Update(Student item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Start updating Student");
            for (int i = 0; i < DataSource.Students.Count; i++)
            {
                if (DataSource.Students[i]?.StudentId == item.StudentId)
                { DataSource.Students.RemoveAt(i);
                    DataSource.Students.Add(item);
                    LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
"Student updated successfully");
                    return;
                   
                }

            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
$"Error,id:{item.StudentId} not found");
            throw new Exception($"Student with ID {item.StudentId} does not exist");

        }
    }
}

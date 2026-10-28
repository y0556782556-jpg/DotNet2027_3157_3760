using Dal;
using DalApi;
using DO;

namespace DalList
{
    internal class StudentImplementation : IStudent
    {
        public int Create(Student item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            bool flag = false;
            for(int i=0; i< DataSource.Students.Count;i++)
            {
                if (DataSource.Students[i]?.studentId == id)
                {
                    DataSource.Students.Remove(DataSource.Students[i]);
                    flag = true;
                    break;
                }
            }
            if (!flag)
                throw new NotExistsExceptions("The id not found");
        }

        public Student? Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student?> ReadAll()
        {
            return new List<Student?>(DataSource.Students);
        }

        public void Update(Student item)
        {
            throw new NotImplementedException();
        }
    }
}

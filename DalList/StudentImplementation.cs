
using DalApi;
using DO;

namespace Dal
{
    internal class StudentImplementation : IStudent
    {
        public int Create(Student item)
        {
            if(DataSource.Students.Any(s=>s?.StudentId==item.StudentId))
                throw new Exception($"Student with ID {item.StudentId} already exists");
           DataSource.Students.Add(item);
            return item.StudentId;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Student? Read(int id)
        {
            return DataSource.Students.FirstOrDefault(
      x => x != null && x.StudentId == id);
        }

        public List<Student> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Student item)
        {
            for (int i = 0; i < DataSource.Students.Count; i++)
            {
                if (DataSource.Students[i]?.StudentId == item.StudentId)
                { DataSource.Students.RemoveAt(i);
                    DataSource.Students.Add(item);
                    return;
                   
                }

            }
            throw new Exception($"Student with ID {item.StudentId} does not exist");
        }
    }
}

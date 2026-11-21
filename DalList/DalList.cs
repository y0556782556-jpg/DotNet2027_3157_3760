using Dal;
using DalApi;

namespace DalList
{ 

   internal sealed class DalList : IDal
    {
        private static readonly DalList instance=new DalList();

        public static DalList Instance
        {
            get { return instance; }
        }
        private DalList()
        {

        }
        public IStudent Student => new StudentImplementation();
        public IAnswer Answer => new AnswerImplementation();
        public IExam Exam => new ExamImplementation();
        public IQuestion Question => new QuestionImplementation();
        public IStudentQuestion StudentQuestion => new StudentQuestionImplementation();
    }
}


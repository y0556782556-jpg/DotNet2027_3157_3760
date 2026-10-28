using DalApi;

namespace DalList
{ 

    internal class DalList : IDal
    {
        public IStudent Student => new StudentImplementation();
        public IAnswer Answer => new AnswerImplementation();
        public IExam Exam => new ExamImplementation();
        public IQuestion Question => new QuestionImplementation();
        public IStudentQuestion StudentQuestion => new StudentQuestionImplementation();
    }
}


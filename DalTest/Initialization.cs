namespace DalTest
{
    using DO;
    using DalApi;
    public static class Initialization
    {private static IDal s_dal;
        static private Dictionary<SubjectType, int> examsId = new Dictionary<SubjectType, int>();//רשימת מבחנים
        static private List<int> questionsId = new List<int>();//רשימת שאלות
        static private List<int> answersId = new List<int>();//רשימת תשובות
        static private List<int> studentsId = new List<int>();//רשימת תלמידית

        private static void CreateExam()
        {
            examsId[SubjectType.Math]= s_dal.Exam.Create(new Exam(1, SubjectType.Math, DateTime.Now.AddDays(7), 2));
            examsId[SubjectType.English] = s_dal.Exam.Create(new Exam(1, SubjectType.English, DateTime.Now.AddDays(5),2));
            examsId[SubjectType.Hebrew] = s_dal.Exam.Create(new Exam(1, SubjectType.Hebrew, DateTime.Now.AddDays(10), 2));
            examsId[SubjectType.Biology] = s_dal.Exam.Create(new Exam(1, SubjectType.Biology, DateTime.Now.AddDays(9), 2));
            examsId[SubjectType.History] = s_dal.Exam.Create(new Exam(1, SubjectType.History, DateTime.Now.AddDays(8), 2));
        }

        private static void CreateStudents()
       {
            studentsId.Add(s_dal.Student.Create(new Student(123, "Rachel Levi", examsId[SubjectType.Math], 100)));
            studentsId.Add(s_dal.Student.Create(new Student(456, "Michal Choen ", examsId[SubjectType.Math], 80)));
            studentsId.Add(s_dal.Student.Create(new Student(789, "Yeal Israeli", examsId[SubjectType.English], 90)));
            studentsId.Add(s_dal.Student.Create(new Student(101, "Chaya Rath", examsId[SubjectType.English], 55)));
            studentsId.Add(s_dal.Student.Create(new Student(753, "Shira Gantz", examsId[SubjectType.Hebrew], 78)));
            studentsId.Add(s_dal.Student.Create(new Student(963, "Ruth Beri", examsId[SubjectType.Hebrew], 96)));
            studentsId.Add(s_dal.Student.Create(new Student(785, "Shani More", examsId[SubjectType.Biology], 100)));
            studentsId.Add(s_dal.Student.Create(new Student(155, "Renana Vinter", examsId[SubjectType.Biology], 90)));
            studentsId.Add(s_dal.Student.Create(new Student(893, "Mali Lev", examsId[SubjectType.History], 89)));
            studentsId.Add(s_dal.Student.Create(new Student(745, "Naama Sompo", examsId[SubjectType.History], 76)));
        }
        private static void CreateStudentQuestion()
        {
            s_dal.StudentQuestion.Create(new StudentQuestion(1, studentsId[0], examsId[SubjectType.Math], questionsId[0], answersId[0]));
            s_dal.StudentQuestion.Create(new StudentQuestion(1, studentsId[1], examsId[SubjectType.English], questionsId[1], answersId[2]));
            s_dal.StudentQuestion.Create(new StudentQuestion(1, studentsId[2], examsId[SubjectType.Hebrew], questionsId[2], answersId[4]));
            s_dal.StudentQuestion.Create(new StudentQuestion(1, studentsId[3], examsId[SubjectType.History], questionsId[3], answersId[6]));
            s_dal.StudentQuestion.Create(new StudentQuestion(1, studentsId[4], examsId[SubjectType.Biology], questionsId[4], answersId[8]));
            s_dal.StudentQuestion.Create(new StudentQuestion(1, studentsId[5], examsId[SubjectType.Math], questionsId[0], answersId[1]));
            s_dal.StudentQuestion.Create(new StudentQuestion(1, studentsId[6], examsId[SubjectType.English], questionsId[1], answersId[3]));
            s_dal.StudentQuestion.Create(new StudentQuestion(1, studentsId[7], examsId[SubjectType.Hebrew], questionsId[2], answersId[5]));
            s_dal.StudentQuestion.Create(new StudentQuestion(1, studentsId[8], examsId[SubjectType.History], questionsId[3], answersId[7]));
            s_dal.StudentQuestion.Create(new StudentQuestion(1, studentsId[9], examsId[SubjectType.Biology], questionsId[4], answersId[9]));
        }
        private static void CreateAnswer()
        {
            answersId.Add(s_dal.Answer.Create(new Answer(1, questionsId[0], "answerCorrect0")));
            answersId.Add(s_dal.Answer.Create(new Answer(1, questionsId[0], "answerUnCorrect0")));
            answersId.Add(s_dal.Answer.Create(new Answer(2, questionsId[1], "answerCorrect1")));
            answersId.Add(s_dal.Answer.Create(new Answer(2, questionsId[1], "answerUnCorrect1")));
            answersId.Add(s_dal.Answer.Create(new Answer(4, questionsId[2], "answerCorrect2")));
            answersId.Add(s_dal.Answer.Create(new Answer(4, questionsId[2], "answerUnCorrect2")));
            answersId.Add(s_dal.Answer.Create(new Answer(1, questionsId[3], "answerCorrect3")));
            answersId.Add(s_dal.Answer.Create(new Answer(1, questionsId[3], "answerUnCorrect3")));
            answersId.Add(s_dal.Answer.Create(new Answer(1, questionsId[4], "answerCorrect4")));
            answersId.Add(s_dal.Answer.Create(new Answer(1, questionsId[4], "answerUnCorrect4")));
            //answersId.Add(s_dal.Answer.Create(new Answer(4, questionsId[5], "answer5")));
            //answersId.Add(s_dal.Answer.Create(new Answer(2, questionsId[6], "answer6")));
            //answersId.Add(s_dal.Answer.Create(new Answer(3, questionsId[7], "answer7")));
            //answersId.Add(s_dal.Answer.Create(new Answer(1, questionsId[8], "answer8")));
            //answersId.Add(s_dal.Answer.Create(new Answer(4, questionsId[9], "answer9")));
        }
        private static void CreateQuestion()
        {
            //questionsId[0]---math answersId[0]
            questionsId.Add(s_dal.Question.Create(new Question(1, SubjectType.Math, "Question0", answersId[0])));
            questionsId.Add(s_dal.Question.Create(new Question(1, SubjectType.English, "Question1", answersId[2])));
            questionsId.Add(s_dal.Question.Create(new Question(1, SubjectType.Hebrew, "Question2", answersId[4])));
            questionsId.Add(s_dal.Question.Create(new Question(1, SubjectType.History, "Question3", answersId[6])));
            questionsId.Add(s_dal.Question.Create(new Question(1, SubjectType.Biology, "Question4", answersId[8])));
            //questionsId.Add(s_dal.Question.Create(new Question(1, SubjectType.Biology, "Question5", answersId[5])));
            //questionsId.Add(s_dal.Question.Create(new Question(1, SubjectType.English, "Question6", answersId[6])));
            //questionsId.Add(s_dal.Question.Create(new Question(1, SubjectType.English, "Question7", answersId[7])));
            //questionsId.Add(s_dal.Question.Create(new Question(1, SubjectType.Hebrew, "Question8", answersId[8])));
            //questionsId.Add(s_dal.Question.Create(new Question(1, SubjectType.Hebrew, "Question9", answersId[9])));
        }
        public static void Initialize(IDal id)
        {
            s_dal = id;
            CreateExam();
            CreateQuestion();
            CreateAnswer();
            CreateStudents();
            CreateStudentQuestion();
        }
    }

}
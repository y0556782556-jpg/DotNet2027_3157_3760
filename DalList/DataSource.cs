using DO;
namespace Dal
{    // מאגר הנתונים בזיכרון:
     // רשימה סטטית לכל ישות,
     // ומחלקת Config שמייצרת מספרים מזהים רצים.

    static internal class DataSource
    {
        //    רשימות עם כל ההפניות לישויות איברים מתאפסים, מאותחלת כרשימה ריקה .
        static internal List<Question?> Questions { get; set; } = new List<Question?>();
        static internal List<Answer?> Answers { get; set; } = new List<Answer?>();
        static internal List<Exam?> Exams { get; set; } = new List<Exam?>();
        static internal List<StudentQuestion?> StudentQuestions { get; set; } = new List<StudentQuestion?>();
        static internal List<Student?> Students { get; set; } = new List<Student?>();
        // מחלקת קונפיגורציה למספרים רצים.
        // לכל מזהה: קבוע התחלתי, מונה סטטי פרטי,
        // ומאפיין get בלבד שמחזיר את הערך הנוכחי ומקדם אותו באחד.
        internal static class Config
        {
            internal const int minExamId = 100;
            static private int examId = minExamId;
            public static int ExamId => examId++;

            internal const int minQuestionId = 100;
            static private int questionId = minQuestionId;
            public static int QuestionId => questionId++;
            internal const int minAnswerId = 100;
            static private int answerId = minAnswerId;
            internal static int AnswerId => answerId++;
            internal const int minStudentQuestionId = 100;
            static private int studentQuestionId = minStudentQuestionId;
            internal static int StudentQuestionId => studentQuestionId++;

        }
    }
}


namespace Dal
{    // מאגר הנתונים בזיכרון:
     // רשימה סטטית לכל ישות,
     // ומחלקת Config שמייצרת מספרים מזהים רצים.
    using DO;
    static internal class DataSource
    {
        //    רשימות עם כל ההפניות לישויות איברים מתאפסים, מאותחלת כרשימה ריקה .
        static internal List<Question?> Questions { get; set; } = new List<Question?>();
        static internal List<Answer?> Answers { get; set; } = new List<Answer?>();
        static internal List<Exam?> Exams { get; set; } = new List<Exam?>();
        static internal List<Student?> Students { get; set; } = new List<Student?>();
        static internal List<StudentQuestion?> StudentQuestions { get; set; } = new List<StudentQuestion?>();
        // מחלקת קונפיגורציה למספרים רצים.
        // לכל מזהה: קבוע התחלתי, מונה סטטי פרטי,
        // ומאפיין get בלבד שמחזיר את הערך הנוכחי ומקדם אותו באחד.
        internal static class Config
        {
            internal const int minTestId = 100;
            static private int testId = minTestId;
            public static int TestId => testId++;

            internal const int minQuestionID = 100;
            static private int questionID = minQuestionID;
            public static int QuestionID => questionID++;
            internal const int minAnswerId = 100;
            static private int answerId = minAnswerId;
            internal static int AnswerId => answerId++;

        }
    }
}

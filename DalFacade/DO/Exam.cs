using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    //יישות זו מייצגת מבחן
    //ותכונותיה הם:מזהה בחינה,נושא הבחינה,תאריך הבחינה וכמות השאלות בבחינה
    public record Exam(
        int examId, SubjectType subjectExam,DateTime examDate, int questionCount)
    {
        //public Enum()
        //{

        //}
    }
}

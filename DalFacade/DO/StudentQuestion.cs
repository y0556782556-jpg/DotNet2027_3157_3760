using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
//יישות זו מייצגת שאלה לנבחן
//תכונותיה הם:תעודת זהות תלמיד,מזהה בחינה,מזהה שאלה ומזהה תשובה שנבחרה
    public record StudentQuestion(
        int studentId,int ExamId,int questionId,int selectedAnswerId)
    {
        //public StudentQuestion()
        //{

        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    //יישות זו מייצגת שאלה במבחן
    //תכונותיה הם:מזהה שאלה,נושא השאלה,תוכן השאלה ומזהה תשובה נכונה
    public record Question(
       int questionId, SubjectType subjectType, string questionContent,int correctAnswerId)
    {
        //public Question()
        //{

        //}
    }
}

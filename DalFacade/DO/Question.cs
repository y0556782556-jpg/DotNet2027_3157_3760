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
       int QuestionId, SubjectType SubjectType, string QuestionContent,int CorrectAnswerId)
    {
        //public Question()
        //{

        //}
    }
}

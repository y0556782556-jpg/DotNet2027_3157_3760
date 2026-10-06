using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    //יישות זו מייצגת תשובה לשאלה במבחן
    //תכונותיה הם:מזהה תשובה,מזהה שאלה ותוכן התשובה
    public record Answer(
        int answerId,int questionId,string answerContent)
    {
        //public Answer()
        //{

        //}
    }
}

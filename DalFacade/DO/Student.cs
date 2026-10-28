using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    //יישות זו מייצגת תלמיד
    //תכונותיה הם:תעודת זהות התלמיד,שם התלמיד,מזהה בחינה וציון התלמיד 
    public record Student(
        int StudentId,string StudentName,int ExamId,int StudentMark)
    {
        //public Student()
        //{

        //}
    }
}

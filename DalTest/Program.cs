using DalApi;
using DalList;
using DO;
using System;
using System.Reflection;
using Tools;
namespace DalTest
{
    internal class Program
    {
        public static readonly IDal s_dal = new DalList.DalList();
        static void Main(string[] args)
        {
            Initialization.Initialize(s_dal);
            string selection = "start";
            while(selection!="0")
            {
                PrintMainMenu();
                selection = Console.ReadLine();
                switch(selection)
                {
                    case "1":
                        SubMenu<Student>("Student", s_dal.Student, GetStudent);
                        break;
                    case "2":
                        SubMenu<Question>("Question", s_dal.Question, GetQuestion);
                        break;
                    case "3":
                        SubMenu<Answer>("Answer", s_dal.Answer, GetAnswer);
                        break;
                    case "4":
                        SubMenu<Exam>("Exam", s_dal.Exam, GetExam);
                        break;
                    case "5":
                        SubMenu<StudentQuestion>("StudentQuestion", s_dal.StudentQuestion, GetStudentQuestion);
                        break;
                    case "6":
                        LogManager.CleanOldLogs();
                        break;
                    case "0":
                        break;
                     default:
                        Console.WriteLine("Worng input,please enter again");
                        break;

                }
            }
        }
         private static void PrintSecondMenu(string name)
         {
            Console.WriteLine("Hi,Select the desired action");
            Console.WriteLine(name+":");
            Console.WriteLine("Press 1 to create,\r\nPress 2 to delete,\r\nPress 3 to update,\r\nPress 4 to read,\r\nPress 5 to read all,\r\nTo back to main menu press 0");
         }
        private static void PrintMainMenu()
        {
            Console.WriteLine("Hi,Select the desired object");
            Console.WriteLine("For a student, press 1,\r\nFor a question, press 2,\r\nFor an answer, press 3,\r\nFor an exam, press 4,\r\nFor a question for a student, press 5,\r\nto exit, press 0,For clean the Log,press 6");
        }
        private static int GetIntInput(string str)
        {
            int result;
            Console.WriteLine(str);
            string selection;
            selection = Console.ReadLine()??"";
            while(!int.TryParse(selection,out result))
            {
                Console.WriteLine("Invalid input\r\nPlease try again");
                selection = Console.ReadLine()??"";
            }
            return result;
        }
        private static string GetStringInput(string str)
        {
            Console.WriteLine(str);
            string selection = Console.ReadLine() ?? "";
            return selection;
        }
        private static DateTime GetDateInput(string str)
        {
            Console.WriteLine(str);
            string selection = Console.ReadLine() ?? "";
            DateTime result;
            while (!DateTime.TryParse(selection, out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid date (yyyy-MM-dd):");
                selection = Console.ReadLine() ?? "";
            }
            return result;
        }

        private static void SubMenu<T>(string name,ICrud<T>crud,Func<bool,T>getParams)
        {
            PrintSecondMenu(name);
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("Wrong input, please enter again");
            }
            try
            {
                switch (selection)
                {
                    case 1:
                        crud.Create(getParams(false));
                        Console.WriteLine("Secces to create");
                        break;
                    case 2:
                        crud.Delete(GetIntInput("Insert id to delete"));
                        Console.WriteLine("Secces to delete");
                        break;
                    case 3:
                        crud.Update(getParams(true));
                        Console.WriteLine("Secces to update");
                        break;
                    case 4:
                        int id = GetIntInput("Insert id to read");
                        T? selectedObject = crud.Read(id);
                        if (selectedObject == null)
                            Console.WriteLine(name + " " + id + "was'nt found");
                        else
                            Console.WriteLine(selectedObject);
                        break;
                    case 5:
                        List<T> selectedList = crud.ReadAll();
                        if (selectedList.Count == 0)
                            Console.WriteLine("There are no " + name);
                        else
                        {
                            foreach (T item in selectedList)
                                Console.WriteLine(item);
                        }
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Worng input,please enter again");
                        break;


                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message); LogManager.WriteToLog(MethodBase.GetCurrentMethod().Name,
MethodBase.GetCurrentMethod().DeclaringType.FullName,
$"Error:{e}");
            }
        }
        private static Student GetStudent(bool isApdate)
        {
            int id = 0;
          if(isApdate)
                id = GetIntInput("Insert id");
            string name = GetStringInput("Insert name");
            int examId = GetIntInput("Insert examId");
            int grade = GetIntInput("Insert grade");
            return new Student(id, name, examId, grade);

        }
        private static StudentQuestion GetStudentQuestion(bool isApdate)
        {
            int studentId = 0;
            if (isApdate)
                studentId = GetIntInput("Insert studentId");
            
            int studentQuestionId = GetIntInput("Insert studentQuestionId");
            int examId = GetIntInput("Insert examId");
            int questionId = GetIntInput("Insert questionId");
            int selecteAnswer = GetIntInput("Insert selecteAnswer");
            return new StudentQuestion(studentQuestionId, studentId, examId, questionId, selecteAnswer);
        }
        private static Question GetQuestion(bool isApdate)
        {
               int questionId = 0;
               if (isApdate)
                    GetIntInput("Insert questionId");
                string questionContent = GetStringInput("Insert questionContent");
                int correctAnswerId = GetIntInput("Insert correctAnswerId");
            SubjectType subjectType = (SubjectType)GetIntInput("Enter subject type(0:math,1:English,2:Hebrew,3:Biology,4:History");
                return new Question(questionId, subjectType,questionContent, correctAnswerId);
        }

        private static Answer GetAnswer(bool isApdate)
        {
            int answerId = 0;
            if (isApdate)
                GetIntInput("Insert answerId");
            int questionId = GetIntInput("Insert questionId");
            string answerContent = GetStringInput("Insert answerContent");
                return new Answer(answerId, questionId,answerContent);
        }

        private static Exam GetExam(bool isApdate)
        {
            int examId = 0;
            if (isApdate)
                GetIntInput("Insert examId");
            SubjectType subjectExam = (SubjectType)GetIntInput("Enter subject type(0:math,1:English,2:Hebrew,3:Biology,4:History");
            int questionCount = GetIntInput("Insert questionCount");
            DateTime date = GetDateInput("Enter exam date (yyyy-MM-dd):");
            return new Exam(examId, subjectExam,date, questionCount);
        }

    }
}

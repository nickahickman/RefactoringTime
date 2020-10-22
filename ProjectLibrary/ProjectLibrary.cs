using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectLibrary
{
    public class GTKYC
    {
        public static void GetToKnowYourClassmates()
        {
            List<StudentInfo> students = new List<StudentInfo>
            {
                new StudentInfo("Anakin", "Tatooine", "Blue Milk"),
                new StudentInfo("Boba Fett", "Kamino", "Uj Cake"),
                new StudentInfo("Krennic", "Lexru", "Just Desserts"),
                new StudentInfo("Palpatine", "Corellia", "Absithe"),
                new StudentInfo("Thrawn", "Rentor", "Ysalamiri Roast")
            };

            while (true)
            {
                MyLibs.ConsoleLibrary.DrawTitle("Get to Know Your Classmates", "program");

                PrintStudentRoster(students);

                string userAction = MyLibs.UserInputLibrary.GetUserResponse($"Would you like to learn more about a student or add a new student? (learn more/add)");
                while (userAction != "learn more" && userAction != "add")
                {
                    userAction = MyLibs.UserInputLibrary.GetUserResponse($"I didn't understand that. Would you like to learn more about a student or add a new student? (learn more/add)");
                }

                if (userAction == "learn more")
                {
                    string studentID = MyLibs.UserInputLibrary.GetUserResponse($"Enter the ID of the student you want to know more about 0 - {students.Count - 1}");
                    while (!IsValidInteger(studentID))
                    {
                        studentID = MyLibs.UserInputLibrary.GetUserResponse($"Invalid entry: Enter the ID of the student you want to know more about 0 - {students.Count - 1}");
                    }
                    int targetStudent = int.Parse(studentID);

                    while (!StudentExists(students, targetStudent))
                    {
                        targetStudent = int.Parse(MyLibs.UserInputLibrary.GetUserResponse($"Student not found. Enter the ID of the student you want to know more about 0 - {students.Count - 1}"));
                    }

                    string userQuery = MyLibs.UserInputLibrary.GetUserResponse($"Do you want to know {GetStudentName(students, targetStudent)}'s favorite food or hometown?");
                    while (userQuery != "hometown" && userQuery != "favorite food" && userQuery != "favorite animal")
                    {
                        userQuery = MyLibs.UserInputLibrary.GetUserResponse($"I can only tell you about {GetStudentName(students, targetStudent)}'s favorite food, hometown, or favorite animal. Which would you like to know?");
                    }

                    Console.WriteLine(GetStudentFact(students, targetStudent, userQuery));

                    if (!MyLibs.UserInputLibrary.UserWantsToContinue("Would you like information on another student?", "I didn't understand that."))
                    {
                        Console.WriteLine("Thanks, see you next time!");
                        break;
                    }
                }
                else {
                    AddNewStudent(students);
                }

                Console.Clear();
            }
        }

        public class StudentInfo
        { 

            private string name;
            private string homeTown;
            private string favoriteFood;
            
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Hometown
            {
                get { return homeTown; }
                set { homeTown = value; }
            }

            public string FavoriteFood
            { 
                get { return favoriteFood; }
                set { favoriteFood = value; }
            }

            public StudentInfo(string Name, string Hometown, string Favoritefood)
            {
                name = Name;
                homeTown = Hometown;
                favoriteFood = Favoritefood;
            }

        }

        public static void PrintStudentRoster(List<StudentInfo> students)
        {
            MyLibs.ConsoleLibrary.DrawTitle("Current Roster", "section");

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"ID {i} - {students[i].Name}");
            }

            Console.WriteLine("");
        }

        public static string GetStudentName(List<StudentInfo> students, int index)
        {
            return students[index].Name;
        }

        public static string GetStudentFact(List<StudentInfo> students, int index, string query)
        {
            if (query == "favorite food")
            {
                return $"{GetStudentName(students, index)}'s favorite food is {students[index].FavoriteFood}";
            }
            else
            {
                return $"{GetStudentName(students, index)}'s hometown is {students[index].Hometown}";
            }
        }

        public static bool StudentExists(List<StudentInfo> students, int studentIndex)
        {
            return studentIndex >= 0 && studentIndex < students.Count;
        }

        public static bool IsValidInteger(string userResponse)
        {
            return userResponse.All(Char.IsDigit);
        }

        public static void AddNewStudent(List<StudentInfo> students)
        {
            string studentName = MyLibs.UserInputLibrary.GetUserResponse("What is the new student's name?");
            string hometown = MyLibs.UserInputLibrary.GetUserResponse("What is the new student's hometown?");
            string favoriteFood = MyLibs.UserInputLibrary.GetUserResponse("What is the new student's favorite food?");

            students.Add(new StudentInfo(studentName, hometown, favoriteFood));
        }
    }
}

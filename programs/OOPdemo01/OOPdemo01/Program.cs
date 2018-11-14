using System;

namespace OOPdemo01
{
    class Student
        {
            //public string name;
            //public int mark;
            //public char gender;

            private string mName;
            private int mMark;
            private char mGender;

            public Student()
            {
                mName = "No Name";
                mMark = 0;
                mGender = 'U';
            }

            public Student (string name, int mark, char gender)
            {
                mName = name;
                mMark = mark;
                mGender = gender;
            }

            public string Name
            {
                get
                {
                    return mName;
                }
                set
                {
                    if (value.Trim().Length > 0)
                        mName = value;
                }
            }

            public int Mark
            {
                get
                {
                    return mMark;
                }

                set
                {
                    if (value >= 0 && value <= 100)
                        mMark = value;
                }
            }

            public char Gender
            {
                get
                {
                    return mGender;
                }

                set
                {
                    if (value == 'M' || value == 'F' || value == 'U')
                        mGender = value;
                }
            }
     }

    class Program
    {
        static void DisplayStudents(Student[] students, int size)
        {
            Console.WriteLine("Name \tMark \tGender");
            Console.WriteLine("---- \t---- \t------");
            for (int i = 0; i < size; i++)
            {
                var stu = students[i];
                Console.WriteLine($"{stu.Name} \t{stu.Mark} \t {stu.Gender}");
            }
        }

        static int EnterStudents(Student[] students)
        {
            int studentCount = 0;
            bool enterAnotherStudent = true;

            while (enterAnotherStudent)
            {
                var newStudent = new Student();
                Console.Write("Enter Name: ");
                newStudent.Name = Console.ReadLine();
                Console.Write("Enter Student Mark: ");
                newStudent.Mark = int.Parse(Console.ReadLine());
                Console.Write("Enter Gender: ");
                newStudent.Gender = char.Parse(Console.ReadLine());

                students[studentCount] = newStudent;
                studentCount++;

                if (studentCount >= students.Length)
                {
                    enterAnotherStudent = false;
                } else
                {
                    Console.Write("Enter more Students (y/n): ");
                    if (char.Parse(Console.ReadLine()) == 'n')
                        enterAnotherStudent = false;
                }
            }

            return studentCount;
        }
        
        static void Main(string[] args)
        {
            var students = new Student[5];
            int count = EnterStudents(students);
            DisplayStudents(students, count);

            //Student student1 = new Student();
            //student1.Name = "Dudley Do-Right";
            //student1.Mark = 49;
            //student1.Gender = 'M';
            //Console.WriteLine($"Name   = {student1.Name}");
            //Console.WriteLine($"Mark   = {student1.Mark}");
            //Console.WriteLine($"Gender = {student1.Gender}\n");

            //Student student2 = new Student();
            //student2.Name = "Sandra Bullock";
            //student2.Mark = -100;
            //student2.Gender = 'U';
            //Console.WriteLine($"Name   = {student2.Name}");
            //Console.WriteLine($"Mark   = {student2.Mark}");
            //Console.WriteLine($"Gender = {student2.Gender}");

            //var stu3 = new Student("Alejandro", 85, 'M');
            //Console.WriteLine($"Name   = {stu3.Name}");
            //Console.WriteLine($"Mark   = {stu3.Mark}");
            //Console.WriteLine($"Gender = {stu3.Gender}");

        }
    }
}

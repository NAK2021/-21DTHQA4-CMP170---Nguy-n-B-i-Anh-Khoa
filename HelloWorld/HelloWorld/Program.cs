// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace HelloWorld
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }

    public class Student2
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public int StandardID { get; set; }
    }
    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }

    public class Student3
    {
        public int StudentsID { get; set; }
        public string StudentName { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
    public class Car
    {
        public string name { get; set; }
        public int price { get; set; }
    }
    public class Users
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int salary { get; set; }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }



    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.StudentID == y.StudentID
            && x.StudentName.ToLower() == y.StudentName.ToLower())
                return true;
            return false;
        }
        public int GetHashCode(Student obj)
        {
            return obj.StudentID.GetHashCode();
        }
    }

    class Program
    {

        /*public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }*/


        public static void Test1()
        {
            List<int> integerListA = new List<int>()
            {1,2,3,4,5,6,7,8,9,10,11,12,13};
            //Linq Query using Query Syntax
            var QuerySyntax = from obj in integerListA
                              where obj > 5
                              select obj;
            //Execution
            Console.Write("The number of the Method Syntax is: ");
            foreach (var item in QuerySyntax)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
            List<int> integerListB = new List<int>()
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            //LINQ Query using Method Syntax
            var MethodSyntax = integerListB.Where(obj => obj > 5).ToList();
            //Execution
            Console.Write("The number of the Method Syntax is: ");
            foreach (var item in MethodSyntax)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
        }
        
        public static void Test2()
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John Walton", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin Herick", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill Anderson", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram Morgan" , Age = 20} ,
            new Student() { StudentID = 5, StudentName = "Ron Alexander" , Age = 15 }
            };
            // Check the age of each student
            var teenAgerStudent = studentList.Where(s => s.Age > 12 && s.Age < 20);

            Console.WriteLine("Teen age Students:");
            foreach (Student std in teenAgerStudent)
            {
                Console.WriteLine(std.StudentName);
            }
            //Check name length of each student
            var TeenStudentName = studentList.Where(a => a.StudentName.Length > 11);
            Console.WriteLine(" Student name lenght :");
            foreach (Student student in TeenStudentName)
            {
                Console.WriteLine(student.StudentName);
            }
            //Check Student ID which is odd number or even number 
            var StudentEvenOddID = studentList.Where(id => id.StudentID % 2 == 0);
            Console.WriteLine(" Student even ID:");
            foreach (Student studentid in StudentEvenOddID)
            {
                Console.WriteLine(studentid.StudentName);
            }
        }

        public static void Test3()
        {
            // Student collection
            IList<Student2> studentList = new List<Student2>() {
                new Student2() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                new Student2() { StudentID = 2, StudentName = "Steve", Age = 21, StandardID = 1 } ,
                new Student2() { StudentID = 3, StudentName = "Bill", Age = 18, StandardID = 2 } ,
                new Student2() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                new Student2() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };
            Console.WriteLine("Multiple Select and where Operator");
            var studentNames = studentList.Where(s => s.Age > 18)
            .Select(s => s)
            .Where(st => st.StandardID > 0)
            .Select(s => s.StudentName);

            foreach (var name in studentNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("Select teen age");
            var teenStudentsName = from s in studentList
                                   where s.Age > 12 && s.Age < 20
                                   select new { StudentName = s.StudentName };

            teenStudentsName.ToList().ForEach(s => Console.WriteLine(s.StudentName));
            Console.WriteLine("Query returns list students group by StandardID");
            var studentsGroupByStandard = from s in studentList
                                          group s by s.StandardID into sg
                                          orderby sg.Key
                                          select new { sg.Key, sg };
            foreach (var group in studentsGroupByStandard)
            {
                Console.WriteLine("StandardID {0}:", group.Key);
                foreach (var Item in group.sg)
                {
                    Console.WriteLine(Item.StudentName);
                }
            }

            Console.WriteLine("List of students by ascending order of StandardID and Age.");

            var sortedStudents = from s in studentList
                                 orderby s.StandardID, s.Age
                                 select new
                                 {
                                     StudentName = s.StudentName,
                                     Age = s.Age,
                                     StandardID = s.StandardID
                                 };
            sortedStudents.ToList().ForEach(s => Console.WriteLine("Student Name: {0}, Age: {1}, StandardID: {2}  ", s.StudentName, s.Age, s.StandardID));
            Console.WriteLine("Nested Query");
            var nestedQueries = from s in studentList
                                where s.Age > 18 && s.StandardID ==
                                (from std in standardList
                                 where std.StandardName == "Standard 1"
                                 select std.StandardID).FirstOrDefault()
                                select s;
            nestedQueries.ToList().ForEach(s => Console.WriteLine(s.StudentName));
        }

        public static void Test4()
        {
            // Student collection
            IList<Student2> studentList = new List<Student2>() {
                new Student2() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                new Student2() { StudentID = 2, StudentName = "Steve", Age = 21, StandardID = 1 } ,
                new Student2() { StudentID = 3, StudentName = "Bill", Age = 18, StandardID = 2 } ,
                new Student2() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                new Student2() { StudentID = 5, StudentName = "Ron" , Age = 21 },
                new Student2() { StudentID = 6, StudentName = "Peter" , Age = 17 }};

            Console.WriteLine("Count() method");
            var totalStudents = studentList.Count();
            Console.WriteLine("---Total Students: {0}", totalStudents);
            var adultStudents = studentList.Count(s => s.Age >= 18);
            Console.WriteLine("---Number of Adult Students: {0}", adultStudents);
            Console.WriteLine("Max() method");
            var oldest = studentList.Max(s => s.Age);
            Console.WriteLine("---Oldest Student Age: {0}", oldest);
            Console.WriteLine("Sum() method");
            var sumOfAge = studentList.Sum(s => s.Age);
            Console.WriteLine("---Sum of all student's age: {0}", sumOfAge);
            var numOfAdults = studentList.Sum(s => {
                if (s.Age >= 18)
                    return 1;
                else
                    return 0;
            });
            Console.WriteLine("---Total Adult Students: {0}", numOfAdults);
        }

        public static void Test5()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve", Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 25 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var distinctStudents = studentList.Distinct(new StudentComparer());
            foreach (var std in distinctStudents)
                Console.WriteLine(std.StudentName);
        }

        public static void Test6()
        {
            List<Employee> listEmployees = new List<Employee>
            {
                new Employee { ID= 1001, Name = "Priyanka", Salary = 80000 },
                new Employee { ID= 1002, Name = "Anurag", Salary = 90000 },
                new Employee { ID= 1003, Name = "Preety", Salary = 80000 }
            };
            // In the below statement the LINQ Query is only defined and not executed
            // If the query is executed here, then the result should not display Santosh
            IEnumerable<Employee> result = (from emp in listEmployees
                                           where emp.Salary == 80000
                                           select emp).ToList(); // result will not update if using ToList
            // Adding a new employee with Salary = 80000 to the collection listEmployees
            listEmployees.Add(new Employee
            {
                ID = 1004,
                Name = "Santosh",
                Salary = 80000
            });
            // The LINQ query is actually executed when we iterate thru using a for each loop
            // This is proved because Santosh is also included in the result
            foreach (Employee emp in listEmployees)
            {
                Console.WriteLine($" {emp.ID} {emp.Name} {emp.Salary}");
            }
        }

        public static void Test7()
        {
            // Student collection
            IList<Student3> studentList = new List<Student3>()
            {
                new Student3() { StudentsID = 1, StudentName = "John", Location = "London", Date = DateTime.Parse("2001-04-01") },
                new Student3() { StudentsID = 2, StudentName = "Jenny", Location = "New York", Date = DateTime.Parse("1997-12-11") },
                new Student3() { StudentsID = 3, StudentName = "Andrew", Location = "Boston", Date = DateTime.Parse("1987-02-22") },
                new Student3() { StudentsID = 4, StudentName = "Peter", Location = "Prague", Date = DateTime.Parse("1936-03-24") },
                new Student3() { StudentsID = 5, StudentName = "Anna", Location = "Bratislava", Date = DateTime.Parse("1973-11-18") },
                new Student3() { StudentsID = 6, StudentName = "Albert", Location = "Bratislava", Date = DateTime.Parse("1940-12-11") },
                new Student3() { StudentsID = 7, StudentName = "Adam", Location = "Trnava", Date = DateTime.Parse("1983-12-01") },
                new Student3() { StudentsID = 8, StudentName = "Robert", Location = "Bratislava", Date = DateTime.Parse("1935-05-15") },
                new Student3() { StudentsID = 9, StudentName = "Robert", Location = "Prague", Date = DateTime.Parse("1998-03-14") },
            };
            IList<Car> carList = new List<Car>()
        {
            new Car() { name = "Audi ", price = 52642} ,
            new Car() { name = "Mercedes ", price = 57127} ,
            new Car() { name = "Skoda ", price = 9000} ,
            new Car() { name = "Volvo ", price = 29000} ,
            new Car() { name = "Bently ", price = 350000} ,
            new Car() { name = "Citoren ", price = 21000} ,
            new Car() { name = "Hummer ", price = 41400} ,
            new Car() { name = "Volkswagen ", price = 261000} ,
        };
            IList<Users> userlist = new List<Users>()
            {
                new Users(){ FirstName ="John", LastName="Doe",salary=1230},
                new Users(){ FirstName ="Lucy", LastName="Novak",salary=670},
                new Users(){ FirstName ="Ben", LastName="Walter",salary=2050},
                new Users(){ FirstName ="Robin", LastName="Brown",salary=2300},
                new Users(){ FirstName ="Amy", LastName="Doe",salary=1250},
                new Users(){ FirstName ="Joe", LastName="Draker",salary=1190},
                new Users(){ FirstName ="Janet", LastName="Dow",salary=980},
                new Users(){ FirstName ="Alber", LastName="Novak",salary=1930},
            };
            // Check student who lived in Bratislava
            Console.WriteLine("Student who lived in Bratislava: ");
            var StudentLocation = studentList.Where(s => s.Location == "Bratislava");
            foreach (Student3 local in StudentLocation)
            {
                Console.Write(local.StudentName); Console.WriteLine();
            }
            // Check cars whose price is between 30000 and 100000                   
            Console.WriteLine(" Cars whose price is between 30000 and 100000 are :");
            var CarPrice = from c in carList
                           where c.price >= 30000 && c.price <= 100000
                           select new { name = c.name };
            CarPrice.ToList().ForEach(c => Console.WriteLine(c.name));
            // Check  Sort ascending by last name and salary
            // Check users who have salary higher than 1500
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(" Sort ascending by last name and salary: ");
            // Sort the usersList by last name and then by salary in ascending order
            var sortedUsers = userlist.OrderBy(user => user.LastName).ThenBy(user => user.salary).ToList();
            // Display the sorted list
            foreach (var user in sortedUsers)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}, Salary: {user.salary}");
            }
            Console.WriteLine(" Users who have salary higher than 1500");
            // Check user who have salary higher than 1500
            var userSalary = from u in userlist
                             where u.salary >= 1500
                             select new { u.FirstName, u.LastName };
            userSalary.ToList().ForEach(s => Console.WriteLine($"{s.FirstName}  {s.LastName} "));
            // the code that you want to measure comes here
            /*watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(watch.ElapsedMilliseconds);*/
        }

        static void Main(string[] args)
        {
            //Moi vao
            /*string str = "khoa5544321";
            string str_hash = "";
            str_hash = Program.CreateMD5(str);
            var new_Account = new User(str, str_hash);
            Console.WriteLine("Password: " + str);
            Console.WriteLine("MD5-Hashed Password: " + str_hash.ToLower());*/

            //Dang nhap
            //Tim thay duoc tai khoan var find_user = <SQL.Command>
            /*User cur_Account = (User)new_Account;
            Console.WriteLine("\nUse hashed password to find actual password");
            Console.WriteLine("Actual Password: " + cur_Account.CheckAccout(str_hash));*/
            //Khi dang nhap mat khau se chay qua MD5-hash --> moi tim kiem trong db dua tren ma hash
            Test6();
        }
    }
}

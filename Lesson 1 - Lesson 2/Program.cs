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

        //Lesson 1:
        public static void Test1()
        {
            
            Console.Write("Please enter a name for the new directory:");
            string DirName = Console.ReadLine();
            // Checking if string is empty or not
            if (DirName != String.Empty)
            {
                // Creating the Directory
                Directory.CreateDirectory(DirName);  //Create Directory
                // Checking Directory is created
                // Successfully or not
                if (Directory.Exists(DirName))
                {
                    Console.WriteLine("The directory was created!");
                    Console.ReadKey();
                }
            }
        }



        public static void Test2()
        {
            Console.WriteLine("Please enter a name for the new directory:");
            string DirName = Console.ReadLine();
            // Checking if string is empty or not
            if (DirName != String.Empty)
            {
                // Creating the Directory
                Directory.CreateDirectory(DirName);
                // Checking Directory is created
                // Successfully or not
                if (Directory.Exists(DirName))
                {
                    Console.WriteLine("The directory was created!");
                    /*Console.ReadKey();*/
                }
            }
            Console.WriteLine("Please enter a name of the directory to renamed:");
            DirName = Console.ReadLine();
            if (Directory.Exists(DirName))
            {
                Console.WriteLine("Please enter a new name for this directory:");
                string newDirName = Console.ReadLine();
                if (newDirName != String.Empty)
                {
                    // to rename directory
                    Directory.Move(DirName, newDirName);
                    // checking directory has
                    // been renamed or not
                    if (Directory.Exists(newDirName))
                    {
                        Console.WriteLine("The directory was renamed to " + newDirName);
                        /*Console.ReadKey();*/
                    }
                }
            }
        }

        public static void Test3()
        {
            Console.WriteLine("Please enter a name for the new directory:");
            string DirName = Console.ReadLine();
            // Checking if string is empty or not
            if (DirName != String.Empty)
            {
                // Creating the Directory
                Directory.CreateDirectory(DirName);
                // Checking Directory is created
                // Successfully or not
                if (Directory.Exists(DirName))
                {
                    Console.WriteLine("The directory was created!");
                    //Console.ReadKey();
                }
            }
            Console.WriteLine("Enter the directory name you want to delete:");
            DirName = Console.ReadLine();
            // Checking if Directory Exist or not
            if (Directory.Exists(DirName))
            {
                // This will delete the
                // Directory if it is empty
                Directory.Delete(DirName);
                // checking if directory if
                // deleted successfully or not
                if (Directory.Exists(DirName) == false)
                    Console.WriteLine("Directory deleted successfully...");
            }

            else
            {
                Console.WriteLine("Directory {0} does not exist!", DirName);
            }
        }


        public static void Test4()
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\NAK\\source\\repos\\HelloWorld\\tmp.txt");
            // To write on the console screen
            Console.WriteLine("Enter the Text that you want to write on File");
            // To read the input from the user
            string str = Console.ReadLine();
            // To write a line in buffer
            sw.WriteLine(str);
            // To write in output stream
            sw.Flush();
            // To close the stream
            sw.Close();

        }

        public static void Test5() 
        {
            StreamReader sr = new StreamReader("C:\\Users\\NAK\\source\\repos\\HelloWorld\\tmp.txt");
            Console.WriteLine("Content of the File:");
            // This is use to specify from where
            // to start reading input stream
            sr.BaseStream.Seek(0, SeekOrigin.Current);
            // To read line from input stream
            string str = sr.ReadLine();
            // To read the whole file line by line
            while (str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            sr.Close();
        }

        //Lesson 2:
        public static void Test6()
        {
            List<string> mylist = new List<string>();
            // Inserting elements into List
            mylist.Add("C#");
            mylist.Add("Java");
            mylist.Add("C");
            mylist.Add("C++");
            // To get an Enumerator
            // for the List.
            List<string>.Enumerator em = mylist.GetEnumerator();
            //display(em);
            while (em.MoveNext())
            {
                string val = em.Current;
                Console.WriteLine(val);
            }
        }

        public static void Test7()
        {
            Queue<string> strQ = new Queue<string>();
            strQ.Enqueue("H");
            strQ.Enqueue("e");
            strQ.Enqueue("l");
            strQ.Enqueue("l");
            strQ.Enqueue("o");
            /*Console.WriteLine("Total elements: {0}", strQ.Count); //prints 5
            if (strQ.Count > 0)
            {
                Console.WriteLine(strQ.Peek()); //prints H
                Console.WriteLine(strQ.Peek()); //prints H
            }*/
            Console.WriteLine("Total elements: {0}", strQ.Count); //prints 5
            while (strQ.Count > 0)
                Console.Write(strQ.Dequeue()); //prints Hello
            Console.WriteLine("\nTotal elements: {0}", strQ.Count); //prints 0
        }

        public static void Test8()
        {
            Stack<int> myStack = new Stack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            Console.Write("Number of elements in Stack: {0} \n", myStack.Count);
            while (myStack.Count > 0)
                Console.Write(myStack.Pop() + ",");
            Console.Write("\nNumber of elements in Stack: {0}", myStack.Count);
        }

        public static void Test9()
        {
            // Creating a linkedlist
            // Using LinkedList class
            LinkedList<String> my_list = new LinkedList<String>();
            // Adding elements in the LinkedList
            // Using AddLast() method
            my_list.AddLast("Zoya");
            my_list.AddLast("Shilpa");
            my_list.AddLast("Rohit");
            my_list.AddLast("Rohan");
            my_list.AddLast("Juhi");
            my_list.AddLast("Zoya");
            // Initial number of elements
            Console.WriteLine("Best students of XYZ " +"university initially:");
            foreach (string str in my_list)
            {
                Console.Write(str + ", ");
            }
            Console.WriteLine("\nBest students of XYZ" +" university in 2000 (Delete first):");
            my_list.Remove(my_list.First);
            foreach (string str in my_list)
            {
                Console.Write(str + ", ");
            }
            // After using Remove(T) method
            Console.WriteLine("\nBest students of XYZ" + " university in 2001 (Delete Rohit):");
            my_list.Remove("Rohit");
            foreach (string str in my_list)
            {
                Console.Write(str + ", ");
            }
            // After using RemoveFirst() method
            Console.WriteLine("\nBest students of XYZ" + " university in 2002 (Delete first):");
            my_list.RemoveFirst();
            foreach (string str in my_list)
            {
                Console.Write(str + ", ");
            }
            // After using RemoveLast() method
            Console.WriteLine("\nBest students of XYZ" + " university in 2003 (Delete last):");
            my_list.RemoveLast();
            foreach (string str in my_list)
            {
                Console.Write(str + ", ");
            }
            Console.WriteLine("\nNumber of students: {0}", my_list.Count);
            // After using Clear() method
            my_list.Clear();
            Console.WriteLine("Number of students (After clearing): {0}",my_list.Count);
        }

        public static void Test10()
        {
            SortedList<int, string> numberNames = new SortedList<int, string>(){
                {3, "Three"},
                {5, "Five"},
                {1, "One"}};
            Console.WriteLine("---Initial key-values--");
            foreach (KeyValuePair<int, string> kvp in numberNames)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);
            numberNames.Add(6, "Six");
            numberNames.Add(2, "Two");
            numberNames.Add(4, "Four");
            Console.WriteLine("---After adding new key-values--");
            foreach (var kvp in numberNames)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);
            numberNames.Remove(2);//removes key 2 pair
            Console.WriteLine("---After removing key (2)--");
            for (int i = 0; i < numberNames.Count; i++)
            {
                Console.WriteLine("key: {0}, value: {1}", numberNames.Keys[i],numberNames.Values[i]);
            }
        }

        public static void Test11()
        {
            Dictionary<int, string> My_dict1 = new Dictionary<int, string>();
            // Adding key/value pairs
            // in the Dictionary
            // Using Add() method
            My_dict1.Add(1123, "Welcome");
            My_dict1.Add(1124, "to");
            My_dict1.Add(1125, "C#");
            Console.WriteLine("---Dictionary 1--");
            foreach (KeyValuePair<int, string> ele1 in My_dict1)
            {
                Console.WriteLine("{0} and {1}",
                ele1.Key, ele1.Value);
            }
            Console.WriteLine();
            Dictionary<string, string> My_dict2 = new Dictionary<string, string>(){
                {"a.1", "Dog"},
                {"a.2", "Cat"},
                {"a.3", "Pig"} };
            Console.WriteLine("---Dictionary 2--");
            foreach (KeyValuePair<string, string> ele2 in My_dict2)
            {
                Console.WriteLine("{0} and {1}", ele2.Key, ele2.Value);
            }
            Console.WriteLine();
            // Using Remove() method
            Console.WriteLine("---Delete key 1123--");
            My_dict1.Remove(1123);
            Console.WriteLine("---Find key 1123--");
            if (My_dict1.ContainsKey(1123) == true)
            {
                Console.WriteLine("Key is found...!!");
            }
            else
            {
                Console.WriteLine("Key is not found...!!");
            }
            Console.WriteLine();
            Console.WriteLine("---Add key 1123 with value GeeksforGeeks--");
            My_dict1[1123] = "GeeksforGeeks";
            Console.WriteLine("---Find Value GeeksforGeeks--");
            if (My_dict1.ContainsValue("GeeksforGeeks") == true)
            {
                Console.WriteLine("Value is found...!!");
            }
            else
            {
                Console.WriteLine("Value is not found...!!");
            }
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
            Test11();
        }
    }
}

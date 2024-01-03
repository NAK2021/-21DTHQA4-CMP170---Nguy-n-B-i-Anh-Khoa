using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
            var db = new Lesson_9Entities();
            var select = from s in db.Students select s;
            String st = "";
            foreach (var item in select)
            {
                st = st + "ID: " + item.StudentID.ToString() + System.Environment.NewLine;
                st = st + "Name: " + item.StudentName.ToString() +
                System.Environment.NewLine;
                st = st + "Gender: " + item.StudentGender.ToString() +
                System.Environment.NewLine;
                st = st + "Address: " + item.Address.ToString() + System.Environment.NewLine;
                st = st  + System.Environment.NewLine;
                st = st  + System.Environment.NewLine;
            }
            this.textBox1.Text = st;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new Lesson_9Entities();
            Student aStudent;
            if (db.Students.Find(5) == null)
            {
                aStudent = new Student();
                aStudent.StudentID = 5;
                aStudent.StudentName = "Nguyen Tri Dung";
                aStudent.StudentGender = "Male";
                aStudent.Address = "11 Le Lai";
                db.Students.Add(aStudent);
                db.SaveChanges();
            }
            Form1_Load(sender,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var db = new Lesson_9Entities();
            Student aStudent;
            aStudent = db.Students.Where(d => d.StudentID == 5).FirstOrDefault() as Student;
            if(aStudent != null)
            {
                aStudent.StudentName = "Nguyen Van Linh";
                db.SaveChanges();
            }
            Form1_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var db = new Lesson_9Entities();
            Student aStudent;
            aStudent = db.Students.Where(d => d.StudentID == 5).FirstOrDefault() as Student;
            if (aStudent != null)
            {
                db.Students.Remove(aStudent);
                db.SaveChanges();
            }
            
            Form1_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Lesson_9Entities db = new Lesson_9Entities())
            {
                Student aStudent;
                // add
                aStudent = new Student();
                aStudent.StudentID = 5;
                aStudent.StudentName = "Nguyen Tri Dung";
                aStudent.StudentGender = "Male";
                aStudent.Address = "11 Le Lai";
                db.Students.Add(aStudent);
                // update
                aStudent = db.Students.Where(d => d.StudentID == 3).FirstOrDefault() as Student;
                aStudent.StudentName = "Nguyen Van Linh";
                //delete
                /*aStudent = db.Students.Where(d => d.StudentID == 3).FirstOrDefault() as Student;
                db.Students.Remove(aStudent);*/
                db.SaveChanges();
                Form1_Load(sender, e);
            }
        }
    }
}

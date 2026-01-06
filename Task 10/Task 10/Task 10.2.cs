using System;
using System.Collections;
using System.Linq;

public class Student
{
    public string StudentName { get; set; }
    public int StudentID { get; set; }
    public double Marks { get; set; }

    public Student(string name, int id, double marks)
    {
        StudentName = name;
        StudentID = id;
        Marks = marks;
    }
}

public class StudentDAL
{
    private ArrayList students = new ArrayList();

    public bool AddStudent(Student s)
    {
        students.Add(s);
        return true;
    }

    public bool DeleteStudent(int id)
    {
        foreach (Student s in students)
        {
            if (s.StudentID == id)
            {
                students.Remove(s);
                return true;
            }
        }
        return false;
    }

    public double SearchStudent(int id)
    {
        foreach (Student s in students)
        {
            if (s.StudentID == id)
                return s.Marks;
        }
        return -1;
    }

    public Student[] GetAllStudents()
    {
        return students.Cast<Student>().ToArray();
    }
}

class Program
{
    static void Main(string[] args)
    {
        StudentDAL dal = new StudentDAL();

        dal.AddStudent(new Student("madhan", 1, 85.5));
        dal.AddStudent(new Student("Kumar", 2, 90.0));

        Console.WriteLine("Search Student ID 1:");
        double marks = dal.SearchStudent(1);

        if (marks != -1)
            Console.WriteLine("Marks: " + marks);
        else
            Console.WriteLine("Student Not Found");

        Console.WriteLine("\nAll Students:");
        foreach (Student s in dal.GetAllStudents())
        {
            Console.WriteLine($"{s.StudentID} - {s.StudentName} - {s.Marks}");
        }
    }
}
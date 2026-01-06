using System;
using System.Collections;
using System.Linq;


public class Employee
{
    public string EmployeeName { get; set; }
    public int EmployeeID { get; set; }
    public double Salary { get; set; }

    public Employee(string name, int id, double salary)
    {
        EmployeeName = name;
        EmployeeID = id;
        Salary = salary;
    }
}


public class EmployeeDAL
{
    private ArrayList employees = new ArrayList();

    public bool AddEmployee(Employee e)
    {
        employees.Add(e);
        return true;
    }

    public bool DeleteEmployee(int id)
    {
        foreach (Employee e in employees)
        {
            if (e.EmployeeID == id)
            {
                employees.Remove(e);
                return true;
            }
        }
        return false;
    }

    public string? SearchEmployee(int id)   
    {
        foreach (Employee e in employees)
        {
            if (e.EmployeeID == id)
                return e.EmployeeName;
        }
        return null;
    }

    public Employee[] GetAllEmployeesListAll()
    {
        return employees.Cast<Employee>().ToArray();
    }
}


class Program
{
    static void Main(string[] args)
    {
        EmployeeDAL dal = new EmployeeDAL();

        dal.AddEmployee(new Employee("madhan", 127, 50000));
        dal.AddEmployee(new Employee("kumar", 125, 30000));

        Console.WriteLine("Search Employee ID 127:");
        string? name = dal.SearchEmployee(127);

        if (name != null)
            Console.WriteLine("Employee Found: " + name);
        else
            Console.WriteLine("Employee Not Found");

        Console.WriteLine("\nAll Employees:");
        foreach (Employee e in dal.GetAllEmployeesListAll())
        {
            Console.WriteLine($"{e.EmployeeID} - {e.EmployeeName} - {e.Salary}");
        }
    }
}
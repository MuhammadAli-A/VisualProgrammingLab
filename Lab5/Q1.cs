using System;

public enum Department
{
    ComputerScience,
    Mathematics,
    Physics,
    Chemistry,
    Biology,
    Literature,
    History
}

public class Person
{
    private string name;

    // No-argument constructor
    public Person()
    {
        name = null;
    }

    // Multi-argument constructor
    public Person(string name)
    {
        this.name = name;
    }

    // Public property
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

public class Student : Person
{
    private string regNo;
    private int age;
    private Department program;

    // No-argument constructor
    public Student() : base()
    {
        regNo = null;
        age = 0;
        program = Department.ComputerScience; // Set default value for enum
    }

    // Multi-argument constructor
    public Student(string name, string regNo, int age, Department program) : base(name)
    {
        this.regNo = regNo;
        this.age = age;
        this.program = program;
    }

    // Public properties
    public string RegNo
    {
        get { return regNo; }
        set { regNo = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Department Program
    {
        get { return program; }
        set { program = value; }
    }
}

public class Program
{
    public static void Main()
    {
        // Creating an instance using no-argument constructor
        Student student1 = new Student();

        // Student 1 Details
        student1.Name = "Muhammad Ali";
        student1.RegNo = "233510";
        student1.Age = 22;
        student1.Program = Department.ComputerScience;
        Console.WriteLine($"Student1:\nName = {student1.Name}\nRegNo = {student1.RegNo}\nAge = {student1.Age}\nProgram = {student1.Program}\n");

        // Creating another instance using no-argument constructor
        Student student2 = new Student();

        // Student 2 Details
        student2.Name = "Muhammad Hassan";
        student2.RegNo = "233516";
        student2.Age = 19;
        student2.Program = Department.ComputerScience;
        Console.WriteLine($"Student2:\nName = {student2.Name}\nRegNo = {student2.RegNo}\nAge = {student2.Age}\nProgram = {student2.Program}\n");



    }
}

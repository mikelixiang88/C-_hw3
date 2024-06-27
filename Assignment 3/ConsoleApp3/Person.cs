namespace ConsoleApp3;

// A Program to demonstrate Abstraction/, /Encapsulation/, /Inheritance/ and
// /Polymorphism/
public interface IPersonService {
    decimal CalculateSalary();
    int CalculateAge();
    void AddAddress(string address);
    List<string> GetAddresses();
}

public interface IStudentService : IPersonService {
    void CalculateGPA();
    void EnrollInCourse(Course course);
}

public interface IInstructorService : IPersonService {
    void CalculateBonus();
    void AssignDepartment(Department department);
}
public abstract class Person : IPersonService {
    public string Name { get; set; }
    public DateTime DateOfBirth { get; private set; }
    protected decimal salary;
    private List<string> addresses = new List<string>();

    public Person(string name, DateTime dob) {
        Name = name;
        DateOfBirth = dob;
    }

    public virtual decimal CalculateSalary() {
        if (salary < 0) throw new ArgumentException("Salary cannot be negative.");
        return salary;
    }

    public int CalculateAge() {
        return DateTime.Now.Year - DateOfBirth.Year;
    }

    public void AddAddress(string address) {
        addresses.Add(address);
    }

    public List<string> GetAddresses() {
        return addresses;
    }
}

public class Student : Person, IStudentService {
    private List<Course> courses = new List<Course>();

    public Student(string name, DateTime dob) : base(name, dob) { }

    public void EnrollInCourse(Course course) {
        courses.Add(course);
        course.EnrollStudent(this);
    }

    public void CalculateGPA() {
        // Implementation to calculate GPA based on course grades
    }
}

public class Instructor : Person, IInstructorService {
    public DateTime JoinDate { get; private set; }
    public Department Department { get; private set; }
    private decimal bonus;

    public Instructor(string name, DateTime dob, DateTime joinDate) : base(name, dob) {
        JoinDate = joinDate;
    }

    public override decimal CalculateSalary() {
        return base.CalculateSalary() + bonus;
    }

    public void CalculateBonus() {
        int years = DateTime.Now.Year - JoinDate.Year;
        bonus = years * 1000;  // Simple bonus calculation
    }

    public void AssignDepartment(Department department) {
        Department = department;
        department.Head = this;
    }
}

public class Course {
    public List<Student> EnrolledStudents { get; private set; } = new List<Student>();

    public void EnrollStudent(Student student) {
        EnrolledStudents.Add(student);
    }
}

public class Department {
    public Instructor Head { get; set; }
    public decimal Budget { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();
}
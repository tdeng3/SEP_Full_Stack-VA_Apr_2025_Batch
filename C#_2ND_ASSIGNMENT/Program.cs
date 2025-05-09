using System;
// See https://aka.ms/new-console-template for more information

using _03ObjectOrientedProgramming;
using _03ObjectOrientedProgramming.DataModel;
using _03ObjectOrientedProgramming.Repository;
using _03ObjectOrientedProgramming.Services;

// Console.WriteLine("Hello, World!");

_03ObjectObjectOrientedPrograming OOP = new _03ObjectObjectOrientedPrograming();
OOP.runTest();
OOP.runProgram1();
OOP.runFibonacci();

var courses = CourseRepository.CreateCourses();
var instructors = InstructorRepository.CreateSampleInstructors();
var department = new Department("Computer Science", DateTime.Now, DateTime.Now.AddYears(1), 100000m)
{
    Head = instructors[0] // Assigning the first instructor from the list
};

department.AddCourse(courses[0]);
department.AddCourse(courses[1]);
department.AddCourse(courses[2]);

var students = StudentRepository.CreateStudents(courses);

Console.WriteLine("tudents");
foreach (var student in students)
{
    Console.WriteLine($"{student.FirstName} {student.LastName} - GPA: {student.CalculateGPA()}");
}

Console.WriteLine("\nInstructors");
foreach (var instructor in instructors)
{
    Console.WriteLine($"{instructor.FirstName} {instructor.LastName} - Salary: {instructor.CalculateSalary()}");
}

Console.WriteLine("\nDepartment");
Console.WriteLine($"Department: {department.Name}");
Console.WriteLine($"Head: {department.Head.FirstName} {department.Head.LastName}");
Console.WriteLine($"Budget: {department.Budget}");
Console.WriteLine($"Courses Offered: {string.Join(", ", department.CoursesOffered.ConvertAll(c => c.CourseName))}");

Ball redBall = new Ball(5, new Color(255, 0, 0));
Ball greenBall = new Ball(7, new Color(0, 255, 0));
Ball blueBall = new Ball(9, new Color(0, 0, 255));

Console.WriteLine("\nThrow red ball 3 times.");
redBall.Throw();
redBall.Throw();
redBall.Throw();

Console.WriteLine("Throw green ball 1 time.");
greenBall.Throw();

Console.WriteLine("Pop green ball.");
greenBall.Pop();

Console.WriteLine("Attempt to throw green ball again.");
greenBall.Throw();

Console.WriteLine("Popp blue ball before any throw.");
blueBall.Pop();

Console.WriteLine("Attenmpt to throw blue ball.");
blueBall.Throw();

Console.WriteLine($"Red Ball:    Throw {redBall.GetThrowCount()} times");
Console.WriteLine($"Green Ball:  Throw {greenBall.GetThrowCount()} times");
Console.WriteLine($"Blue Ball:   Throw {blueBall.GetThrowCount()} times");

using EntityFrameworkIntro.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;


SoftUniContext context = new SoftUniContext();
Console.WriteLine(GetEmployeesInPeriod(context)); 

static string GetEmployeesInPeriod(SoftUniContext context)
{
    StringBuilder sb = new StringBuilder();
    var emloyees = context.Employees
        .Where(e => e.Projects.Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
        .ToList();

    foreach (var employee in emloyees)
    {
        sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager!.FirstName} {employee.Manager!.LastName}");
        foreach (var project in employee.Projects)
        {
            sb.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
        }
    }
    return sb.ToString().Trim();
}

static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
{
    StringBuilder sb = new StringBuilder();
    var employees = context.Employees
        .Where(e => e.Department.Name == "Research and Development")
        .Select(e => new
        {
            e.FirstName,
            e.LastName,
            DepartmentName = e.Department.Name,
            e.Salary
        })
        .OrderBy(e => e.Salary)
        .ThenByDescending(e=>e.FirstName)
        .ToList();
    foreach (var e in employees)
    {
        sb.AppendLine($"{e.FirstName} from {e.DepartmentName} - {Math.Round(e.Salary, 2)}");
    }
    return sb.ToString().Trim();
}

static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
{
    StringBuilder sb = new StringBuilder();
    var employees = context.Employees
        .Where(e => e.Salary > 50000)
        .OrderBy(e => e.FirstName)
        .ToList();
    foreach (var e in employees)
    {
        sb.AppendLine($"{e.FirstName} - {Math.Round(e.Salary, 2)}");
    }
    return sb.ToString().Trim();
}

static string GetEmployeesFullInformation(SoftUniContext context)
{
    StringBuilder sb = new StringBuilder();
    var employees = context.Employees
        .OrderBy(e => e.EmployeeId)
        .ToList();
    foreach (var e in employees) 
    {
        sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {Math.Round(e.Salary,2)}");
    }
    return sb.ToString().Trim();
}


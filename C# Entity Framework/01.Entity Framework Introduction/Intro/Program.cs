using Intro;
using System.Text;

SoftUniContext context = new SoftUniContext();
Console.WriteLine(GetLatestProjects(context));


static string GetEmployee147(SoftUniContext context)
{
    StringBuilder sb = new StringBuilder();
    Employee employee = context.Employees.Find(147)!;
    var projects = employee.Projects
        .OrderBy(p => p.Name);
    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
    foreach (var project in projects)
    {
        sb.AppendLine($"{project.Name}");
    }
    return sb.ToString().Trim();
}

static string GetLatestProjects(SoftUniContext context)
{
    StringBuilder sb = new StringBuilder();
    var projects = context.Projects
        .Select(p => new
        {
            p.Name,
            p.Description,
            p.StartDate
        })
        .OrderByDescending(p => p.StartDate)
        .ThenBy(p=>p.Name)
        .Take(10)
        .ToList();
    foreach (var p in projects)
    {
        sb.AppendLine($"{p.Name}");
        sb.AppendLine($"{p.Description}");
        sb.AppendLine($"{p.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
        sb.AppendLine();
    }

    return sb.ToString().Trim();
}

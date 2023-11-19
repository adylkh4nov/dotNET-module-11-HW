using dotNET_module_11_HW;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Кол-во сотрудников: ");
        int numberOfEmployees = int.Parse(Console.ReadLine());

        Employee[] employees = new Employee[numberOfEmployees];

        for (int i = 0; i < numberOfEmployees; i++)
        {
            Console.WriteLine($"Сотрудник № {i+1}");
            employees[i] = ReadEmployeeData();
        }

        PrintAllEmployeesInfo(employees);

        Console.Write("Введите должность: ");
        string position = Console.ReadLine();
        Console.WriteLine("\n");
        PrintEmployeesByPosition(employees, position);

        PrintManagersAboveAvgClerkSalary(employees);

        Console.Write("Дата приема на работу (dd/MM/yyyy): ");
        Console.WriteLine("\n");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        PrintEmployeesHiredAfterDate(employees, date);

        Console.Write("Введите пол (M/F) или 'A' чтобы выбрать все: ");
        Console.WriteLine("\n");
        char genderChoice = char.ToUpper(Console.ReadKey().KeyChar);
        PrintEmployeesByGender(employees, genderChoice);
    }

    // Методы для выполнения задания
    static void PrintAllEmployeesInfo(Employee[] employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine(employee.ToString());
        }
    }

    static void PrintEmployeesByPosition(Employee[] employees, string position)
    {
        foreach (var employee in employees)
        {
            if (employee.Position.ToLower() == position.ToLower())
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }

    static void PrintManagersAboveAvgClerkSalary(Employee[] employees)
    {
        decimal clerkTotalSalary = 0;
        int clerkCount = 0;

        foreach (var employee in employees)
        {
            if (employee.Position.ToLower() == "clerk")
            {
                clerkTotalSalary += employee.Salary;
                clerkCount++;
            }
        }
        decimal avgClerkSalary = clerkTotalSalary / clerkCount;
        Console.WriteLine($"average clerk salary: {avgClerkSalary}");
        if (clerkCount > 0)
        {
            

            var managersAboveAvgClerkSalary = employees
                .Where(emp => emp.Position.ToLower() == "manager" && emp.Salary > avgClerkSalary)
                .OrderBy(emp => emp.FullName);

            foreach (var manager in managersAboveAvgClerkSalary)
            {
                Console.WriteLine(manager.ToString());
            }
        }
        else
        {
            Console.WriteLine("No clerks found to calculate average salary.");
        }
    }


    static void PrintEmployeesHiredAfterDate(Employee[] employees, DateTime date)
    {
        var employeesAfterDate = employees
            .Where(emp => emp.EmploymentDate > date)
            .OrderBy(emp => emp.FullName);

        foreach (var employee in employeesAfterDate)
        {
            Console.WriteLine(employee.ToString());
        }
    }

    static void PrintEmployeesByGender(Employee[] employees, char gender)
    {
        var employeesByGender = employees
            .Where(emp => gender == 'A' || emp.Gender == gender)
            .OrderBy(emp => emp.FullName);

        foreach (var employee in employeesByGender)
        {
            Console.WriteLine(employee.ToString());
        }
    }

    static Employee ReadEmployeeData()
    {
        Console.Write("Имя: ");
        string fullName = Console.ReadLine();

        Console.Write("Должность: ");
        string position = Console.ReadLine();

        Console.Write("Дата приема на работу (dd/MM/yyyy): ");
        DateTime employmentDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.Write("Пол (M/F): ");
        char gender = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        Console.Write("ЗП: ");
        decimal salary = decimal.Parse(Console.ReadLine());

        return new Employee
        {
            FullName = fullName,
            Position = position,
            EmploymentDate = employmentDate,
            Gender = gender,
            Salary = salary
        };
    }
}

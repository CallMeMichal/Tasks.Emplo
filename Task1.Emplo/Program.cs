using Task1.Emplo.Models;
using Task1.Emplo.Services;

namespace Task1.Emplo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Jan Kowalski", SuperiorId = null },
                new Employee { Id = 2, Name = "Kamil Nowak", SuperiorId = 1 },
                new Employee { Id = 3, Name = "Anna Mariacka", SuperiorId = 1 },
                new Employee { Id = 4, Name = "Andrzej Abacki", SuperiorId = 2 }
            };

            var service = new EmployeeHierarchyService();
            service.FillEmployeesStructure(employees);

            var row1 = service.GetSuperiorRowOfEmployee(2, 1); // row1 = 1
            var row2 = service.GetSuperiorRowOfEmployee(4, 3); // row2 = null
            var row3 = service.GetSuperiorRowOfEmployee(4, 1); // row3 = 2

            Console.WriteLine($"Row1: {row1}");
            Console.WriteLine($"Row2: {row2}");
            Console.WriteLine($"Row3: {row3}");
        }
    }
}

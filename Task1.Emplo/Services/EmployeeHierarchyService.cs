using Task1.Emplo.Models;

namespace Task1.Emplo.Services
{
    public class EmployeeHierarchyService
    {
        private List<EmployeesStructure> _employeesStructure = new List<EmployeesStructure>();

        public List<EmployeesStructure> FillEmployeesStructure(List<Employee> employees)
        {
            _employeesStructure.Clear();

            foreach (var employee in employees)
            {
                FindAllSuperiors(employee, employees);
            }

            return _employeesStructure;
        }

        private void FindAllSuperiors(Employee employee, List<Employee> allEmployees)
        {
            var currentEmployee = employee;
            int level = 1;

            while (currentEmployee.SuperiorId.HasValue)
            {
                var superior = allEmployees.FirstOrDefault(e => e.Id == currentEmployee.SuperiorId.Value);
                if (superior != null)
                {
                    if (!_employeesStructure.Any(es => es.EmployeeId == employee.Id &&
                                                      es.SuperiorId == superior.Id &&
                                                      es.Level == level))
                    {
                        _employeesStructure.Add(new EmployeesStructure
                        {
                            EmployeeId = employee.Id,
                            SuperiorId = superior.Id,
                            Level = level
                        });
                    }

                    currentEmployee = superior;
                    level++;
                }
                else
                {
                    break;
                }
            }
        }

        public int? GetSuperiorRowOfEmployee(int employeeId, int superiorId)
        {
            var relation = _employeesStructure
                .FirstOrDefault(es => es.EmployeeId == employeeId && es.SuperiorId == superiorId);

            return relation?.Level;
        }
    }
}

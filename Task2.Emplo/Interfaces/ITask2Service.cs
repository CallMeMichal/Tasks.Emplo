using Task2.Emplo.Models.Database;
using Task2.Emplo.Models.DTO;

namespace Task2.Emplo.Interfaces
{
    public interface ITask2Service
    {
        int CountFreeDaysForEmployee(Employee employee, List<Vacation> vacations, VacationPackage vacationPackage);
        Task<List<EmployeeDTO>> GetAllEmployeesWithVacationsAsync();
        Task<List<EmployeeDTO>> GetNetEmployeesWithVacationIn2019Async();
        Task<List<TeamDTO>> GetTeamsWithoutVacationsIn2019Async();
        bool IfEmployeeCanRequestVacation(Employee employee, List<Vacation> vacations, VacationPackage vacationPackage);
    }
}

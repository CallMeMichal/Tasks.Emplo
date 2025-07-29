using Task2.Emplo.Interfaces;
using Task2.Emplo.Models.Database;
using Task2.Emplo.Models.DTO;
using Task2.Emplo.Repositories;

namespace Task2.Emplo.Services
{
    public class Task2Service : ITask2Service
    {
        private readonly Task2Repository _repository;

        public Task2Service(Task2Repository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Zwracany jest lista pracowników, którzy są w zespole .NET i mają wykorzystane dni urlopowe w 2019 roku.
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeDTO>> GetNetEmployeesWithVacationIn2019Async()
        {
            var employees = await _repository.GetNetEmployeesWithVacationIn2019Async();
            var employeeDtos = employees.Select(employee => new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                TeamId = employee.TeamId,
                VacationPackageId = employee.VacationPackageId,
                TeamName = employee.Team?.Name,
            }).ToList();

            return employeeDtos;
        }

        /// <summary>
        /// Zwracany jest lista pracowników, którzy mają wykorzystane dni urlopowe w bieżącym roku.
        /// W przypadku uzytkownika ktory ma np. wykorzystane 10 godzin urlopu, to zostanie to przeliczone na dni urlopowe (10 godzin / 8 godzin = 1.25 dnia).
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeDTO>> GetAllEmployeesWithVacationsAsync()
        {
            var employees = await _repository.GetEmployeesWithUsedVacationsCurrentYearAsync();

            var employeeDtos = employees.Select(employee => new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                TeamId = employee.TeamId,
                VacationPackageId = employee.VacationPackageId,
                TeamName = employee.Team?.Name,
                UsedVacationDaysCurrentYear = Math.Round(
                    employee.Vacations.Sum(v => v.NumberOfHours) / 8.0, 2)
            }).ToList();

            return employeeDtos;
        }

        /// <summary>
        /// Zwracany jest lista zespołów, które nie mają żadnych urlopów w 2019 roku.
        /// </summary>
        /// <returns></returns>
        public async Task<List<TeamDTO>> GetTeamsWithoutVacationsIn2019Async()
        {
            var teams = await _repository.GetTeamsWithoutVacationsIn2019Async();

            var teamDtos = teams.Select(team => new TeamDTO
            {
                Id = team.Id,
                Name = team.Name
            }).ToList();

            return teamDtos;
        }


        /// <summary>
        /// Zadanie 3: Zlicza ilość dni urlopowych, które zostały pracownikowi w danym roku.
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="vacations"></param>
        /// <param name="vacationPackage"></param>
        /// <returns></returns>
        public int CountFreeDaysForEmployee(Employee employee, List<Vacation> vacations,VacationPackage vacationPackage)
        {
            if (vacationPackage == null || vacations == null || employee == null)
            {
                return 0;
            }
            var totalDays = vacationPackage.GrantedDays;
            var usedDays = vacations
                .Where(v => v.EmployeeId == employee.Id && v.DateSince.Year == DateTime.Now.Year)
                .Sum(v => v.NumberOfHours) / 8.0;
            return (int)(totalDays - usedDays);
        }

        /// <summary>
        /// Zadanie 4: Sprawdza, czy pracownik może jeszcze złożyć wniosek o urlop.
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="vacations"></param>
        /// <param name="vacationPackage"></param>
        /// <returns></returns>
        public bool IfEmployeeCanRequestVacation(Employee employee, List<Vacation> vacations,VacationPackage vacationPackage)
        {
            if (employee == null || vacations == null || vacationPackage == null)
            {
                return false;
            }
            var freeDays = CountFreeDaysForEmployee(employee, vacations, vacationPackage);
            return freeDays > 0;
        }
    }
}

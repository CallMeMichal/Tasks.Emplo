using Microsoft.EntityFrameworkCore;
using System.Linq;
using Task2.Emplo.Models;
using Task2.Emplo.Models.Database;

namespace Task2.Emplo.Repositories
{
    public class Task2Repository
    {
        private readonly AppDbContext _context;

        public Task2Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetNetEmployeesWithVacationIn2019Async()
        {
            // wszystkie ktore zaczynaja sie nawet w 2019

            return await _context.Employees
                .Where(e => e.Team.Name == ".NET" &&
                           e.Vacations.Any(v => v.DateSince.Year <= 2020 && v.DateUntil.Year >= 2018 )
                           )
                .ToListAsync();
        }


/*        return await _context.Employees
                .Where(e => e.Team.Name == ".NET" &&
                           e.Vacations.Any(v => v.DateSince.Year == 2019 && )
                           )
                .ToListAsync();*/

        public async Task<List<Team>> GetTeamsWithoutVacationsIn2019Async()
        {
            return await _context.Teams
                .Where(t => !t.Employees.Any(e =>
                    e.Vacations.Any(v => v.DateSince.Year == 2019)))
                .ToListAsync();
        }

        // pracownik + liczba dni wykorzystanych w tym roku

        public async Task<List<Employee>> GetEmployeesWithUsedVacationsCurrentYearAsync()
        {
            var currentYear = DateTime.Now.Year;
            var today = DateTime.Now.Date;

            var employess = await _context.Employees.ToListAsync(); // uzytkownicy
            var vacationsCurrentYear = await _context.Vacations
                .Where(v => v.DateSince.Year <= currentYear && v.DateUntil.Year >= currentYear && v.DateUntil < today) // bierze urlopy ktore sa zakonczone,
                .ToListAsync();

            var employeesWithVacations = employess
                .Where(emp => vacationsCurrentYear.Any(v => v.EmployeeId == emp.Id))
                .ToList();
            return employeesWithVacations;
        }
    }
}

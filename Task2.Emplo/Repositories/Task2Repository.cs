using Microsoft.EntityFrameworkCore;
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
            return await _context.Employees
                .Where(e => e.Team.Name == ".NET" &&
                           e.Vacations.Any(v => v.DateSince.Year == 2019))
                .ToListAsync();
        }

        public async Task<List<Team>> GetTeamsWithoutVacationsIn2019Async()
        {
            return await _context.Teams
                .Where(t => !t.Employees.Any(e =>
                    e.Vacations.Any(v => v.DateSince.Year == 2019)))
                .ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesWithUsedVacationsCurrentYearAsync()
        {
            var currentYear = DateTime.Now.Year;
            var today = DateTime.Now.Date;

            return await _context.Employees
                .Where(e => e.Vacations.Any(v =>
                    v.DateSince.Year == currentYear && v.DateUntil < today))
                .ToListAsync();
        }
    }
}

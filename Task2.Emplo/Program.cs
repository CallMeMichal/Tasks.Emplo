
using Microsoft.EntityFrameworkCore;
using Task2.Emplo.Models;
using Task2.Emplo.Models.Database;
using Task2.Emplo.Repositories;
using Task2.Emplo.Services;

namespace Task2.Emplo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("Database"));

            builder.Services.AddScoped<Task2Repository>();
            builder.Services.AddScoped<Task2Service>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // W³¹cz Swagger UI
                app.UseSwagger();
                app.UseSwaggerUI();

                app.MapGet("/", () => Results.Redirect("/swagger"))
                   .ExcludeFromDescription();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();



            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (!context.Teams.Any())
                {
                    var teams = new List<Team>
                    {
                        new Team { Id = 1, Name = ".NET" },
                        new Team { Id = 2, Name = "Java" },
                        new Team { Id = 3, Name = "Frontend" },
                        new Team { Id = 4, Name = "DevOps" }
                    };
                    context.Teams.AddRange(teams);

                    var vacationPackages = new List<VacationPackage>
                    {
                        new VacationPackage { Id = 1, Name = "Standard 2024", GrantedDays = 26, Year = 2024 },
                        new VacationPackage { Id = 2, Name = "Standard 2025", GrantedDays = 26, Year = 2025 },
                        new VacationPackage { Id = 3, Name = "Senior 2024", GrantedDays = 30, Year = 2024 },
                        new VacationPackage { Id = 4, Name = "Senior 2025", GrantedDays = 30, Year = 2025 },
                        new VacationPackage { Id = 5, Name = "Junior 2024", GrantedDays = 20, Year = 2024 },
                        new VacationPackage { Id = 6, Name = "Junior 2025", GrantedDays = 20, Year = 2025 }
                    };
                    context.VacationPackages.AddRange(vacationPackages);

                    context.SaveChanges();

                    var employees = new List<Employee>
                    {
                        new Employee { Id = 1, Name = "Jan Kowalski", TeamId = 1, VacationPackageId = 3 },
                        new Employee { Id = 2, Name = "Anna Nowak", TeamId = 1, VacationPackageId = 2 },
                        new Employee { Id = 3, Name = "Piotr Wiœniewski", TeamId = 1, VacationPackageId = 2 },
                        new Employee { Id = 4, Name = "Maria Kowalczyk", TeamId = 1, VacationPackageId = 4 },
            
                        new Employee { Id = 5, Name = "Tomasz Wójcik", TeamId = 2, VacationPackageId = 3 },
                        new Employee { Id = 6, Name = "Katarzyna Kaczmarek", TeamId = 2, VacationPackageId = 2 },
                        new Employee { Id = 7, Name = "Micha³ Zieliñski", TeamId = 2, VacationPackageId = 6 },
            
                        new Employee { Id = 8, Name = "Agnieszka Szymañska", TeamId = 3, VacationPackageId = 2 },
                        new Employee { Id = 9, Name = "Pawe³ D¹browski", TeamId = 3, VacationPackageId = 6 },
            
                        new Employee { Id = 10, Name = "Magdalena Koz³owska", TeamId = 4, VacationPackageId = 4 },
                        new Employee { Id = 11, Name = "£ukasz Jankowski", TeamId = 4, VacationPackageId = 2 }
                    };
                    context.Employees.AddRange(employees);

                    context.SaveChanges();

                    var vacations = new List<Vacation>
                    {
                        new Vacation
                        {
                            Id = 1,
                            DateSince = new DateTime(2019, 7, 1),
                            DateUntil = new DateTime(2019, 7, 14),
                            NumberOfHours = 112,
                            IsPartialVacation = false,
                            EmployeeId = 1
                        },
                        new Vacation
                        {
                            Id = 2,
                            DateSince = new DateTime(2019, 8, 15),
                            DateUntil = new DateTime(2019, 8, 22),
                            NumberOfHours = 64,
                            IsPartialVacation = false,
                            EmployeeId = 2
                        },
                        new Vacation
                        {
                            Id = 3,
                            DateSince = new DateTime(2019, 12, 23),
                            DateUntil = new DateTime(2019, 12, 31),
                            NumberOfHours = 72,
                            IsPartialVacation = false,
                            EmployeeId = 3
                        },
            
                        new Vacation
                        {
                            Id = 4,
                            DateSince = new DateTime(2019, 6, 3),
                            DateUntil = new DateTime(2019, 6, 7),
                            NumberOfHours = 40,
                            IsPartialVacation = false,
                            EmployeeId = 5
                        },
            
                        new Vacation
                        {
                            Id = 5,
                            DateSince = new DateTime(2025, 1, 2),
                            DateUntil = new DateTime(2025, 1, 8),
                            NumberOfHours = 56,
                            IsPartialVacation = false,
                            EmployeeId = 1
                        },
                        new Vacation
                        {
                            Id = 6,
                            DateSince = new DateTime(2025, 2, 10),
                            DateUntil = new DateTime(2025, 2, 14),
                            NumberOfHours = 40,
                            IsPartialVacation = false,
                            EmployeeId = 2
                        },
                        new Vacation
                        {
                            Id = 7,
                            DateSince = new DateTime(2025, 3, 1),
                            DateUntil = new DateTime(2025, 3, 3),
                            NumberOfHours = 24, 
                            IsPartialVacation = false,
                            EmployeeId = 4
                        },
            
                        new Vacation
                        {
                            Id = 8,
                            DateSince = new DateTime(2025, 9, 1),
                            DateUntil = new DateTime(2025, 9, 14),
                            NumberOfHours = 112,
                            IsPartialVacation = false,
                            EmployeeId = 3
                        },
                        new Vacation
                        {
                            Id = 9,
                            DateSince = new DateTime(2025, 12, 23),
                            DateUntil = new DateTime(2025, 12, 31),
                            NumberOfHours = 72,
                            IsPartialVacation = false,
                            EmployeeId = 5
                        },
            
                        new Vacation
                        {
                            Id = 10,
                            DateSince = new DateTime(2025, 4, 15),
                            DateUntil = new DateTime(2025, 4, 15),
                            NumberOfHours = 4,
                            IsPartialVacation = true,
                            EmployeeId = 6
                        },
                        new Vacation
                        {
                            Id = 11,
                            DateSince = new DateTime(2025, 5, 20),
                            DateUntil = new DateTime(2025, 5, 20),
                            NumberOfHours = 4,
                            IsPartialVacation = true,
                            EmployeeId = 8
                        }
                    };
                    context.Vacations.AddRange(vacations);

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Baza danych ju¿ zawiera dane.");
                }
            }

            app.Run();
        }
    }
}

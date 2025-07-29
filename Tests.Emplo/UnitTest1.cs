using Moq;
using Task2.Emplo.Interfaces;
using Task2.Emplo.Models.Database;

namespace Tests.Emplo
{
    public class UnitTest1
    {
        private readonly Mock<ITask2Service> _task2ServiceMock;

        public UnitTest1()
        {
            _task2ServiceMock = new Mock<ITask2Service>();
        }


        /// <summary>
        /// Pracownik ma jeszcze dni urlopu, więc może prosić o urlop.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Employee_CanRequestVacation_ShouldReturnTrue()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 1,
                Name = "Jan Kowalski",
                TeamId = 1,
                VacationPackageId = 3
            };

            var vacations = new List<Vacation>
            {
                new Vacation
                {
                    Id = 1,
                    DateSince = new DateTime(2024, 7, 1),
                    DateUntil = new DateTime(2024, 7, 14),
                    NumberOfHours = 112,
                    IsPartialVacation = false,
                    EmployeeId = 1
                }
            };

            var vacationPackage = new VacationPackage
            {
                Id = 3,
                Name = "Senior 2024",
                GrantedDays = 30,
                Year = 2024
            };

            _task2ServiceMock
                .Setup(x => x.IfEmployeeCanRequestVacation(employee, vacations, vacationPackage))
                .Returns(true);

            // Act
            var result = _task2ServiceMock.Object.IfEmployeeCanRequestVacation(employee, vacations, vacationPackage);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Wykorzystane wszystkie dni urlopu, więc pracownik nie może już prosić o urlop.
        /// </summary>
        [Fact]
        public void Employee_CantRequestVacation_ShouldReturnFalse()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 2,
                Name = "Anna Nowak",
                TeamId = 1,
                VacationPackageId = 2
            };

            var vacations = new List<Vacation>
            {
                new Vacation
                {
                    Id = 1,
                    DateSince = new DateTime(2025, 1, 1),
                    DateUntil = new DateTime(2025, 1, 31),
                    NumberOfHours = 208,
                    IsPartialVacation = false,
                    EmployeeId = 2
                }
            };

            var vacationPackage = new VacationPackage
            {
                Id = 2,
                Name = "Standard 2025",
                GrantedDays = 26,
                Year = 2025
            };

            _task2ServiceMock
                .Setup(x => x.IfEmployeeCanRequestVacation(employee, vacations, vacationPackage))
                .Returns(false);

            // Act
            var result = _task2ServiceMock.Object.IfEmployeeCanRequestVacation(employee, vacations, vacationPackage);

            // Assert
            Assert.False(result);
        }
    }
}

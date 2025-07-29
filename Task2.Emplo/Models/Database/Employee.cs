using System.ComponentModel.DataAnnotations.Schema;

namespace Task2.Emplo.Models.Database
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TeamId { get; set; }
        public int VacationPackageId { get; set; }

        public virtual Team Team { get; set; } = null!;
        public virtual VacationPackage VacationPackage { get; set; } = null!;
        public virtual List<Vacation> Vacations { get; set; } = null!;
    }
}

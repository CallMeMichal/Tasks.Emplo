using System.Text.Json.Serialization;

namespace Task2.Emplo.Models.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TeamId { get; set; }
        public int VacationPackageId { get; set; }
        public string? TeamName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double UsedVacationDaysCurrentYear { get; set; }
    }
}

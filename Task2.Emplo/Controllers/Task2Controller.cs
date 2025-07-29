using Microsoft.AspNetCore.Mvc;
using Task2.Emplo.Interfaces;
using Task2.Emplo.Services;

namespace Task2.Emplo.Controllers
{

    [ApiController]
    [Route("api/v1/")]
    public class Task2Controller : Controller
    {

        private readonly ITask2Service _task2Service;

        public Task2Controller(Task2Service task2Service)
        {
            _task2Service = task2Service;
        }

        [HttpGet("employee/vacation/2019")]
        public async Task<ActionResult> GetNetEmployeesWithVacationIn2019Async()
        {
            var result = await _task2Service.GetNetEmployeesWithVacationIn2019Async();
            return Ok(result);
        }

        [HttpGet("employee/vacation")]
        public async Task<ActionResult> GetEmployeesWithVacationAsync()
        {
            var result = await _task2Service.GetAllEmployeesWithVacationsAsync();
            return Ok(result);
        }

        [HttpGet("teams/withoutVacation")]
        public async Task<ActionResult> GetTeamsWithoutVacationsIn2019Async()
        {
            var result = await _task2Service.GetTeamsWithoutVacationsIn2019Async();
            return Ok(result);
        }
    }
}

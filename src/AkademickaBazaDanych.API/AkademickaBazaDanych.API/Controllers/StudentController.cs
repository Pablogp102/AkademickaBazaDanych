using AkademickaBazaDanych.Contracts.Students.Commands;
using AkademickaBazaDanych.Contracts.Students.DTOs;
using AkademickaBazaDanych.Contracts.Students.Queries;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace AkademickaBazaDanych.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(IMediator mediator) : Controller
    {
        [HttpPost("add-student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddStudent([FromBody]AddStudentCommand command)
        {
            var id = await mediator.Send(command);
            return Ok(id);
        }
        [HttpDelete("{IndexNumber}/remove-student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveStudent([FromRoute] RemoveStudentCommand command)
        {
            var id = await mediator.Send(command);
            return Ok(id);
        }
        [HttpGet("get-all-students")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<StudentDTO>> GetAllStudents([FromQuery] GetAllStudentsQuery query)
        {
            var result = await mediator.Send(query);
            return result;
        }
        [HttpGet("{LastName}/get-students-by-last-name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<StudentDetailsDTO>> GetStudentByLastName([FromRoute] GetStudentByLastNameQuery query)
        {
            var result = await mediator.Send(query);
            return result;
        }
        [HttpGet("{PeselPart}/get-student-by-pesel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<StudentDetailsDTO>> GetStudentByPESEL([FromRoute] GetStudentsByPeselQuery query)
        {
            var result = await mediator.Send(query);
            return result;
        }

    }
}

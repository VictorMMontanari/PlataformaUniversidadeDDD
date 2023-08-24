using DDD.Infra.MemoryDB.Interfaces;
using DDD.Unimar.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Universidade.AplicationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return Ok(_studentRepository.GetStudents());
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            return Ok(_studentRepository.GetStudentById(id));
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            //Validacao
            if (student.Name.Length < 3 || student.Name.Length > 30)
            {
                return BadRequest("Nome não pode ser menor que 3 ou maior que 30 caracteres!!");
            }

            _studentRepository.InsertStudent(student);
            return CreatedAtAction(nameof(GetById), new { Id = student.StudentId }, student);
        }
    }
}

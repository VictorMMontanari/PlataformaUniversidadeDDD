using DDD.Infra.MemoryDB.Interfaces;
using DDD.Infra.MemoryDB.Repositories;
using DDD.Unimar.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Universidade.AplicationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        readonly IDisciplineRepository _disciplineRepository;

        public DisciplineController(IDisciplineRepository disciplineRepository)
        {
            _disciplineRepository = disciplineRepository;
        }

        [HttpGet]
        public ActionResult<List<Discipline>> Get()
        {
            return Ok(_disciplineRepository.GetDisciplines());
        }

        [HttpPost]
        public ActionResult<Discipline> CreateStudent(Discipline discipline)
        {
            //Validacao
            if (discipline.Name.Length < 3 || discipline.Name.Length > 30)
            {
                return BadRequest("Nome não pode ser menor que 3 ou maior que 30 caracteres!!");
            }

            _disciplineRepository.InsertDiscipline(discipline);
            return CreatedAtAction(nameof(GetById), new { Id = discipline.DisciplineId }, discipline);
        }

        [HttpPut]
        public ActionResult<Discipline> PutStudent(Discipline discipline)
        {
            _disciplineRepository.UpdateDiscipline(discipline);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Discipline discipline)
        {
            try
            {
                if (discipline == null)
                {
                    return BadRequest();
                }
                _disciplineRepository.DeleteDiscipline(discipline);
                return Ok("Aluno deletado com sucesso");
            }
            catch (Exception)
            {
                throw;
            }
        }



        [HttpGet("{id}")]
        public ActionResult<Discipline> GetById(int id)
        {
            return Ok(_disciplineRepository.GetDisciplineById(id));
        }

    }
}

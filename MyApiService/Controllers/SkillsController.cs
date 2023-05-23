using DataAccess.Entities;
using DataAccess.Entities.Relationships;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using static Services.Extensions.DtoMapping;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        public readonly IGenericSv<Skill> _skillSv;
        public readonly IGenericSv<CandidateSkill> _candidateSkillSv;

        public SkillsController(IGenericSv<Skill> candidateSv, IGenericSv<CandidateSkill> candidateSkillSv)
        {
            _skillSv = candidateSv;
            _candidateSkillSv = candidateSkillSv;
        }

        // GET: api/<SkillsController>
        [HttpGet]
        public List<DtoSkill> Get()
        {
            return _skillSv.GetAll().ToDtoList();
        }

        // GET api/<SkillsController>/5
        [HttpGet("{id}")]
        public DtoSkill Get(int id)
        {
            return _skillSv.GetById(id).ToSkillDto();
        }

        // POST api/<SkillsController>
        [HttpPost]
        public Skill Post([FromBody] DtoSkill skillRequest)
        {
            return _skillSv.Add(skillRequest.ToSkill());
        }

        // POST api/<SkillsController>
        [HttpPost]
        [Route("assign")]
        public CandidateSkill AssignCandidateSkill([FromBody] CandidateSkill candidateSkillRequest)
        {
            return _candidateSkillSv.Add(candidateSkillRequest);
        }
    }
}

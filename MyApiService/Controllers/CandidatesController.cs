using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using static Services.Extensions.DtoMapping;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        public readonly IGenericSv<Candidate> _candidateSv;

        public CandidatesController(IGenericSv<Candidate> candidateSv)
        {
            _candidateSv = candidateSv;
        }

        // GET: api/<CandidatesController>
        [HttpGet]
        public List<DtoCandidate> Get()
        {
            return _candidateSv.GetAll().ToDtoList();
        }

        // GET api/<CandidatesController>/5
        [HttpGet("{id}")]
        public DtoCandidate Get(int id)
        {
            return _candidateSv.GetByCondition(candidate => candidate.Id == id, "Skills").ToCandidateDto();
        }

        // POST api/<CandidatesController>
        [HttpPost]
        public Candidate Post([FromBody] DtoCandidate candidateRequest)
        {
            return _candidateSv.Add(candidateRequest.ToCandidate());
        }
    }
}

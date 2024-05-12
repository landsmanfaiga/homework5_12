using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using homework5_11.Data;

namespace homework5_11.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private string _connectionString;
        public CandidateController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr"); 
        }

        [HttpPost]
        [Route("addcandidate")]
        public void AddCandidate(Candidate candidate)
        {
            var repo = new CandidateRepo(_connectionString);
            repo.AddCandidate(candidate);
        }

        [HttpGet]
        [Route("getpending")]
        public List<Candidate> GetPending()
        {
            var repo = new CandidateRepo(_connectionString);
            return repo.GetPending();
        }
        [HttpGet]
        [Route("getrefused")]
        public List<Candidate> GetRefused()
        {
            var repo = new CandidateRepo(_connectionString);
            return repo.GetRefused();
        }
        [HttpGet]
        [Route("getconfirmed")]
        public List<Candidate> GetConfirmed()
        {
            var repo = new CandidateRepo(_connectionString);
            return repo.GetConfirmed();
        }

        [HttpPost]
        [Route("update")]
        public void Update(Candidate candidate)
        {
            var repo = new CandidateRepo(_connectionString);
            repo.Update(candidate);
        }

        [HttpGet]
        [Route("viewone")]
        public Candidate ViewOne(int id)
        {
            var repo = new CandidateRepo(_connectionString);
            return repo.ViewOne(id);
        }
        [HttpGet("getpendingcount")]
        public object GetPendingCount()
        {
            var repo = new CandidateRepo(_connectionString);
            return new { count = repo.GetPendingCount() };
        }
        [HttpGet("getconfirmedcount")]
        public object GetConfirmedCount()
        {
            var repo = new CandidateRepo(_connectionString);
            return new { count = repo.GetConfirmedCount() };
        }
        [HttpGet("getrefusedcount")]
        public object GetRefusedCount()
        {
            var repo = new CandidateRepo(_connectionString);
            return new { count = repo.GetRefusedCount() };
        }
    }
}

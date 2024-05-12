using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5_11.Data
{
    public class CandidateRepo
    {
        private readonly string _connectionString;
        public CandidateRepo(string connectionString)
        {
             _connectionString = connectionString;
        }

        public void AddCandidate(Candidate candidate)
        {
            using var context = new CandidateDataContext(_connectionString);
            context.Candidates.Add(candidate);
            context.SaveChanges();
        }
        public List<Candidate> GetPending()
        {
            using var context = new CandidateDataContext(_connectionString);
            return context.Candidates.Where(c => c.Status == Status.Pending).ToList();
        }
        public List<Candidate> GetConfirmed()
        {
            using var context = new CandidateDataContext(_connectionString);
            return context.Candidates.Where(c => c.Status == Status.Confirmed).ToList();
        }
        public List<Candidate> GetRefused()
        {
            using var context = new CandidateDataContext(_connectionString);
            return context.Candidates.Where(c => c.Status == Status.Refused).ToList();
        }

        public void Update(Candidate candidate)
        {
            using var context = new CandidateDataContext(_connectionString);
            context.Candidates.Update(candidate);
            context.SaveChanges();
        }

        public Candidate ViewOne(int id)
        {
            using var context = new CandidateDataContext(_connectionString);
            return context.Candidates.FirstOrDefault(c => c.Id == id);
        }

        public int GetPendingCount()
        {
            using var context = new CandidateDataContext(_connectionString);
            return context.Candidates.Where(c => c.Status == Status.Pending).Count();
        }
        public int GetConfirmedCount()
        {
            using var context = new CandidateDataContext(_connectionString);
            return context.Candidates.Where(c=> c.Status == Status.Confirmed).Count();
        }
        public int GetRefusedCount()
        {
            using var context = new CandidateDataContext(_connectionString);
            return context.Candidates.Where(c => c.Status == Status.Refused).Count();
        }
    }
}

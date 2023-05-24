using DataAccess;
using DataAccess.Entities.Relationships;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CandidateSkillSv : ICandidateSkillSv
    {
        public readonly MyDbContext _myDbContext;
        private readonly DbSet<CandidateSkill> _DbSet;
        public CandidateSkillSv(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            _DbSet = _myDbContext.Set<CandidateSkill>();
        }

        public void DeleteByComposeKey(int candidatesId, int skillsId)
        {
            var entity = _DbSet.Find(candidatesId, skillsId);

            if (entity is not null)
            {
                _DbSet.Remove(entity);
                _myDbContext.SaveChanges();
            }
                
        }
    }
}

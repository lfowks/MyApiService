using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    public static class DtoMapping
    {
        #region Candidates

        public struct DtoCandidate 
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Summary { get; set; }
            public List<DtoSkill> Skills { get; set; }
        }
        public static Candidate ToCandidate(this DtoCandidate dtoCandidate)
        {
            Candidate candidate = new()
            {
                Id = dtoCandidate.Id,
                Email = dtoCandidate.Email,
                Name = dtoCandidate.Name,
                Summary = dtoCandidate.Summary
            };

            return candidate;
        }
        public static DtoCandidate ToCandidateDto(this Candidate candidate)
        {
            DtoCandidate candidateDto = new()
            {
                Id = candidate.Id,
                Email = candidate.Email,
                Name = candidate.Name,
                Summary = candidate.Summary,
                Skills = candidate.Skills.ToList().ToDtoList()
            };

            return candidateDto;
        }
        public static List<DtoCandidate> ToDtoList(this List<Candidate> lstCandidate)
        {
            return lstCandidate.ConvertAll(new Converter<Candidate, DtoCandidate>(ToCandidateDto));
        }
        public static List<DtoSkill> ToDtoList(this List<Skill> lstSkill)
        {
            return lstSkill.ConvertAll(new Converter<Skill, DtoSkill>(ToSkillDto));
        }

        #endregion

        #region Skills    

        public struct DtoSkill
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public static Skill ToSkill(this DtoSkill dtoSkill)
        {
            Skill skill = new()
            {
                Id = dtoSkill.Id,
                Name = dtoSkill.Name

            };

            return skill;
        }
        public static DtoSkill ToSkillDto(this Skill skill)
        {
            DtoSkill skillDto = new()
            {
                Id = skill.Id,
                Name = skill.Name

            };

            return skillDto;
        }

        #endregion
    }
}

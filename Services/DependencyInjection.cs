using DataAccess.Entities;
using DataAccess.Entities.Relationships;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IGenericSv<Candidate>, GenericSv<Candidate>>();
            services.AddScoped<IGenericSv<Skill>, GenericSv<Skill>>();
            services.AddScoped<IGenericSv<CandidateSkill>, GenericSv<CandidateSkill>>();

            return services;
        }
    }
}

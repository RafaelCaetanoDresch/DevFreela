using DevFreela.Core.DTOs;

namespace DevFreela.Core.Repository
{
    public interface ISkillRepository
    {
        Task<List<SkillDto>> GetAllAsync(); 
    }
}

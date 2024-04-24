namespace DevFreela.Core.Repository;

public interface ISkillRepository
{
    Task<List<SkillDto>> GetAllAsync(); 
}

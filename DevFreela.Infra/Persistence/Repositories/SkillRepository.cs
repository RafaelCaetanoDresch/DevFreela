namespace DevFreela.Infra.Persistence.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly DevFreelaDbContext _context;

    public SkillRepository(DevFreelaDbContext context)
        => _context = context;

    public async Task<List<SkillDto>> GetAllAsync()
    {
        return await _context.Skills
            .AsNoTracking()
            .Select(s => new SkillDto(s.Id, s.Description))
            .ToListAsync();
    }
}

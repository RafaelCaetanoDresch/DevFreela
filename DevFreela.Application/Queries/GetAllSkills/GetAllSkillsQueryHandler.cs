namespace DevFreela.Application.Queries.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDto>>
{
    private readonly ISkillRepository _repository;

    public GetAllSkillsQueryHandler(ISkillRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<SkillDto>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
        var skills = await _repository.GetAllAsync();

        return skills;
    }
}

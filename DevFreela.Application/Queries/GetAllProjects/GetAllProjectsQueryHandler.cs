namespace DevFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
{
    private readonly DevFreelaDbContext _context;

    public GetAllProjectsQueryHandler(DevFreelaDbContext context)
    {
        _context = context;
    }
    public Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = _context.Projects;

        var projectsViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToListAsync();

        return projectsViewModel;
    }
}

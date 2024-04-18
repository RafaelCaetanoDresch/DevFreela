namespace DevFreela.Application.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly DevFreelaDbContext _context;

    public CreateProjectCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project(request.Title,
                                  request.Description,
                                  request.ClientID,
                                  request.FreelancerID,
                                  request.TotalCost);
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();

        return project.Id;
    }
}

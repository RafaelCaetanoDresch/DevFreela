namespace DevFreela.Application.Queries.GetProjectByID;

public class GetProjectByIdCommandHandler : IRequestHandler<GetProjectByIdCommand, Project>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectByIdCommandHandler(IProjectRepository projectRepository) =>
        _projectRepository = projectRepository;

    public async Task<Project> Handle(GetProjectByIdCommand request, CancellationToken cancellationToken)
    {
        return await _projectRepository.GetByIdAsync(request.Id);
    }
}

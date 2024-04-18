namespace DevFreela.Application.Queries.GetProjectByID;

public class GetProjectByIdCommand : IRequest<ProjectDetailDto>
{
    public GetProjectByIdCommand(Guid id)
        => Id = id;

    public Guid Id { get; private set; }
}

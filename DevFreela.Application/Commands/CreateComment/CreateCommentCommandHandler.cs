namespace DevFreela.Application.Commands.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
{
    private readonly IProjectRepository _repository;

    public CreateCommentCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(request.Content, request.UserId, request.ProjectId);
        await _repository.AddCommentAsync(comment);
        return Unit.Value;
    }
}

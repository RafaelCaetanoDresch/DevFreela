namespace DevFreela.Application.Queries.GetUserById;

public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, UserDatailsDto>
{
    private readonly IUserRepository _repository;

    public GetUserByIdCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserDatailsDto> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}

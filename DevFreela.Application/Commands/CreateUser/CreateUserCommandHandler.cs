using DevFreela.Core.Services;

namespace DevFreela.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _repository;
    private readonly IAuthServices _authService;

    public CreateUserCommandHandler(IUserRepository repository, IAuthServices authService)
    {
        _repository = repository;
        _authService = authService;
    }


    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);
        var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

        await _repository.AddAsync(user);

        return user.Id;
    }
}

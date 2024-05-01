using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
{
    private readonly IAuthServices _authServices;
    private readonly IUserRepository _repository;

    public LoginUserCommandHandler(IAuthServices authServices, IUserRepository repository)
    {
        _authServices = authServices;
        _repository = repository;
    }

    public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authServices.ComputeSha256Hash(request.Password);

        var user = await _repository.GetUserByEmailPasswordAsync(request.Email, passwordHash);

        if (user is null) return null;

        //if user exists, generate token
        var token = _authServices.GenerateJwtToken(user.Email, user.Role);
        return new LoginUserViewModel(user.Email, token);
    }
}

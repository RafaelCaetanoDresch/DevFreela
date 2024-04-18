using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUser(Guid id);
        Guid Create(CreateUserInputModel inputModel);
    }
}

using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infra.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly DevFreelaDbContext _dbContext;

    public UserService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Guid Create(CreateUserInputModel inputModel)
    {
        var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return user.Id;
    }

    public UserViewModel GetUser(Guid id)
    {
        var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

        if (user == null)
            return null;

        return new UserViewModel(user.FullName, user.Email);
    }
}

namespace DevFreela.Core.Repository;

public interface IUserRepository
{
    Task AddAsync(User user);

    Task<UserDatailsDto> GetByIdAsync(Guid id);
}

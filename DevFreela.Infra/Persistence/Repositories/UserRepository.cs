namespace DevFreela.Infra.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DevFreelaDbContext _context;

    public UserRepository(DevFreelaDbContext context)
        => _context = context;

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<UserDatailsDto> GetByIdAsync(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user is null) return null;

        return new UserDatailsDto(user.Id, user.FullName, user.Email, user.BirthDate, user.Active);
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .Select(u => new UserDto(u.Id, u.FullName, u.Email, u.Active))
            .ToListAsync();
    }
}

namespace DevFreela.Core.Repository;

public interface IProjectRepository
{
    Task<List<ProjectDto>> GetAllAsync();

    Task<Project> GetByIdAsync(Guid id);
    Task AddAsync(Project project);

    Task AddCommentAsync(ProjectComment comment);
    Task DeleteAsync(Project project);
    Task StartAsync(Project project);
    Task FinishAsync(Project project);
    Task SaveChangesAsync();
}

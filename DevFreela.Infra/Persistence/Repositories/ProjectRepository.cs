﻿namespace DevFreela.Infra.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DevFreelaDbContext _context;

    public ProjectRepository(DevFreelaDbContext context) 
        => _context = context;

    public async Task<List<ProjectDto>> GetAllAsync()
    {
        return await _context.Projects
            .AsNoTracking()
            .Select(p => new ProjectDto(p.Id, p.Title, p.CreatedAt)).ToListAsync();
    }

    public async Task<Project> GetByIdAsync(Guid id)
    {
        var project = await _context.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (project is null) return null;

        return project;
    }

    public async Task AddAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Project project)
    {
        project.Cancel();
        await _context.SaveChangesAsync();
    }

    public async Task StartAsync(Project project)
    {
        project.Start();
        await _context.SaveChangesAsync();
    }

    public async Task FinishAsync(Project project)
    {
        project.Finish();
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task AddCommentAsync(ProjectComment comment)
    {
        await _context.ProjectsComments.AddAsync(comment);
        await _context.SaveChangesAsync();
    }
}

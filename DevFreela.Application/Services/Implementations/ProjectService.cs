using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _dbContext;

    public ProjectService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Guid Create(NewProjectInputModel inputModel)
    {
        var project = new Project(inputModel.Title, 
                                  inputModel.Description, 
                                  inputModel.ClientID, 
                                  inputModel.FreelancerID, 
                                  inputModel.TotalCost);
        _dbContext.Projects.Add(project);
        _dbContext.SaveChanges();
        return project.Id;
    }

    public void CreateComment(CreateCommentInputModel inputModel)
    {
        var comment = new ProjectComment(inputModel.Content, inputModel.UserId, inputModel.ProjectId);
        _dbContext.ProjectsComments.Add(comment);

        _dbContext.SaveChanges();
    }

    public void Delete(Guid Id)
    {
        var project = _dbContext.Projects.FirstOrDefault(x => x.Id == Id);
        if(project is not null)
            project.Cancel();

        _dbContext.SaveChanges();
    }

    public void Finish(Guid Id)
    {
        var project = _dbContext.Projects.FirstOrDefault(x => x.Id == Id);
        if (project is not null)
            project.Finish();

        _dbContext.SaveChanges();
    }

    public List<ProjectViewModel> GetAll(string query)
    {
        var projects = _dbContext.Projects;

        var projectsViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();
        return projectsViewModel;
    }

    public ProjectDetailsViewModel GetById(Guid Id)
    {
        var project = _dbContext.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .FirstOrDefault(x => x.Id == Id);

        if (project is null) return null;

        return new ProjectDetailsViewModel(project.Id,
                                           project.Title,
                                           project.Description,
                                           project.TotalCost,
                                           project.CreatedAt,
                                           project.FinishedAt,
                                           project.Client.FullName,
                                           project.Freelancer.FullName);
    }

    public void Start(Guid Id)
    {
        var project = _dbContext.Projects
            .FirstOrDefault(x => x.Id == Id);
        if (project is not null)
            project.Start();
        _dbContext.SaveChanges();
    }

    public void Update(UpdateProjectInputModel inputModel)
    {
        var project = _dbContext.Projects.FirstOrDefault(x => x.Id == inputModel.Id);

        if (project is not null)
            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        _dbContext.SaveChanges();
    }
}

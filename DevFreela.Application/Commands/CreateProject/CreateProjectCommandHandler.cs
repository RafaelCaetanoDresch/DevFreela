﻿namespace DevFreela.Application.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IProjectRepository _repository;

    public CreateProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project(request.Title,
                                  request.Description,
                                  request.ClientID,
                                  request.FreelancerID,
                                  request.TotalCost);
        
        await _repository.AddAsync(project);

        return project.Id;
    }
}

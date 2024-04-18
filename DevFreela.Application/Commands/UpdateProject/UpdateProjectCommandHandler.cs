namespace DevFreela.Application.Commands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly DevFreelaDbContext _context;

    public UpdateProjectCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (project is not null)
            project.Update(request.Title, request.Description, request.TotalCost);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}

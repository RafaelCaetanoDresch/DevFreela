namespace DevFreela.Application.Commands.UpdateProject;

public class UpdateProjectCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Decimal TotalCost { get; set; }
}

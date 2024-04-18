namespace DevFreela.Application.Commands.CreateProject;

public class CreateProjectCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ClientID { get; set; }
    public Guid FreelancerID { get; set; }
    public Decimal TotalCost { get; set; }
}

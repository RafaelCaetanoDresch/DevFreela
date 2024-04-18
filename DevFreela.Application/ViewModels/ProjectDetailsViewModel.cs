namespace DevFreela.Application.ViewModels;

public class ProjectDetailsViewModel
{
    public ProjectDetailsViewModel(Guid id, 
                                   string title, 
                                   string description, 
                                   decimal totalCost, 
                                   DateTime startedAt, 
                                   DateTime? finishedAt,
                                   string clienteFullName,
                                   string freelancerFullName)
    {
        Id = id;
        Title = title;
        Description = description;
        TotalCost = totalCost;
        StartedAt = startedAt;
        FinishedAt = finishedAt;
        ClientFullName = clienteFullName;
        FreelancerFullName = freelancerFullName;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Decimal TotalCost { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public string ClientFullName { get; private set; }
    public string FreelancerFullName { get; private set; }
}

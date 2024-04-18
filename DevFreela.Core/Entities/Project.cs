using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities;

public class Project : BaseEntity
{
    public Project(string title, 
                   string description, 
                   Guid clientID, 
                   Guid freelancerID, 
                   decimal totalCost)
    {
        Title = title;
        Description = description;
        ClientID = clientID;
        FreelancerID = freelancerID;
        TotalCost = totalCost;

        CreatedAt = DateTime.Now;
        Comments = new();

        Status = ProjectStatusEnum.Created;
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public Guid ClientID { get; private set; }
    public User? Client { get; set; }
    public Guid FreelancerID { get; private set; }
    public User? Freelancer { get; set; }
    public Decimal TotalCost { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public List<ProjectComment> Comments { get; private set; }
    

    public void Cancel()
    {
        if(Status == ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.Canceled;
        }
    }
    public void Start()
    {
        if (Status == ProjectStatusEnum.Created)
        {
            Status = ProjectStatusEnum.InProgress;
            StartedAt = DateTime.Now;
        }
    }
    public void Finish()
    {
        if (Status == ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.Finished;
            FinishedAt = DateTime.Now;
        }
    }

    public void Update(string title, string description, Decimal totalCost)
    {
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
}

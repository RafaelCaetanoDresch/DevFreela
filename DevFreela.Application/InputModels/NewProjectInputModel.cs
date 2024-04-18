namespace DevFreela.Application.InputModels;

public class NewProjectInputModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ClientID { get; set; }
    public Guid FreelancerID { get; set; }
    public Decimal TotalCost { get; set; }
}

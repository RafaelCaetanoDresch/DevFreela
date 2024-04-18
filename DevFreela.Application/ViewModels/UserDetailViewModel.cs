namespace DevFreela.Application.ViewModels;

public class UserDetailViewModel
{
    public UserDetailViewModel(Guid id, 
                               string fullName, 
                               string email, 
                               DateTime birthDate, 
                               bool active)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Active = active;
    }

    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool Active { get; private set; }
}

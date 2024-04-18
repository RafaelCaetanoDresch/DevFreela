namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public CreateUserCommand(Guid id, string fullName, string password, string email, DateTime birthDate)
        {
            Id = id;
            FullName = fullName;
            Password = password;
            Email = email;
            BirthDate = birthDate;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}

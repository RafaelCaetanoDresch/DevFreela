namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public CreateUserCommand(string fullName, string password, string email, DateTime birthDate, string role)
        {
            FullName = fullName;
            Password = password;
            Email = email;
            BirthDate = birthDate;
            Role = role;
        }

        public string FullName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Role { get; private set; }
    }
}

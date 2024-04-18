namespace DevFreela.Application.Queries.GetUserById;

public class GetUserByIdCommand : IRequest<UserDatailsDto>
{
    public Guid Id { get; set; }

    public GetUserByIdCommand(Guid id)
    {
        Id = id;
    }
}

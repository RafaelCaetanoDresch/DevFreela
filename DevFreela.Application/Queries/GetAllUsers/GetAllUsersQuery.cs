namespace DevFreela.Application.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{
    public string Query { get; set; }

    public GetAllUsersQuery(string query)
    {
        Query = query;
    }
}

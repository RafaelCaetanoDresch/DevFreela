namespace DevFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsQuery : IRequest<List<ProjectDto>>
{
    public GetAllProjectsQuery(string query)
    {
        Query = query;
    }

    public string Query { get; set; }
}

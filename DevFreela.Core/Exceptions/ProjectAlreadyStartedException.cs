namespace DevFreela.Core.Exceptions;

public class ProjectAlreadyStartedException : Exception
{
    public ProjectAlreadyStartedException() : base("Project is alredy in Started status")
    {
        
    }
}

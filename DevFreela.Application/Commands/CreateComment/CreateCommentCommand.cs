namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public string Content { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
    }
}

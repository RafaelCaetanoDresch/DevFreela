namespace DevFreela.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity(){}
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

namespace Pipelines.Infra.Data.Models
{
    public abstract class DataEntity
    {
        public Guid Id { get; private set; }

        public DateTime CreatedDate { get; private set; }
        public string CreatedBy { get; private set; }

        public DateTime? UpdatedDate { get; private set; }
        public string? UpdatedBy { get; private set; }

        public DataEntity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            CreatedBy = "System";
        }
    }
}

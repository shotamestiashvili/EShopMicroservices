namespace Ordering.Domain.Abstraction;

public interface IEntity<T> : IEntity
{
    T Id { get; }
}

public interface IEntity
{
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}
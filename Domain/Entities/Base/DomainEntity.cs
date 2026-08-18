namespace Domain.Entities.Base;
public class DomainEntity : ISoftDelete
{
    public DateTime? DeletedOn { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime LastModifiedOn { get; set; } = DateTime.Now;

    public void SetDelete() => DeletedOn = DateTime.Now;
}

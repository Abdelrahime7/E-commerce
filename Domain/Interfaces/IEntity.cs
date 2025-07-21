
namespace Domain.Interface
{
    public interface IEntity : ISoftDelete
    {
        public int Id { get; set; }
    }

}

namespace ToDoAPI.Interfaces
{
    public interface ITransiant
    {
        public Guid Id { get; }
    }

    public class Transiant : ITransiant
    {
        public Guid Id { get; set; }

        public Transiant() { Id = Guid.NewGuid(); }
    }
}

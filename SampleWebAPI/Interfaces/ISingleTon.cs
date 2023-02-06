namespace ToDoAPI.Interfaces
{
    public interface ISingleTon
    {
        public Guid Id { get; }
    }
    public class SingleTon : ISingleTon
    {
        public Guid Id { get; set; }

        public SingleTon() { Id = Guid.NewGuid(); }
    }
}

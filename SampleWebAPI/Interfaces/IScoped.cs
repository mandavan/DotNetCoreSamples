namespace ToDoAPI.Interfaces
{
    public interface IScoped
    {
        public Guid Id { get;  }
    }

    public class Scoped: IScoped
    {
        public Guid Id { get; set; }

        public Scoped() { Id = Guid.NewGuid(); } 

        public Guid GetGuid()
        {
            return new Guid();
        }
    }
}

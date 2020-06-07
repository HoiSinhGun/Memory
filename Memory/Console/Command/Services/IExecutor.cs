namespace Memory.Console.Command.Services
{
    public interface IExecutor<T> where T : BaseCommand<T>
    {
        public T Execute(T command);
    }
}

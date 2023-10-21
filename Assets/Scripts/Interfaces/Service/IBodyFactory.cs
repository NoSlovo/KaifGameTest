namespace Factory.BodyFactory
{
    public interface IBodyFactory : IService
    {
        public SnakeBody Create();
    }
}
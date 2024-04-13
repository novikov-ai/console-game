namespace ComputerGame
{
    public abstract class Resource : Obstacle
    {
        public Resource(Field field) : base(field) { }

        public virtual string GetResource()
        {
            return "resource";
        }
    }
}
namespace ComputerGame.Monsters.Visitors
{
    public interface IVisitor
    {
        public void Visit (Bear bear);
        public void Visit (Wolf wolf);
    }
}
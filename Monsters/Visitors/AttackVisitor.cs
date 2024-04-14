namespace ComputerGame.Monsters.Visitors
{
    public class AttackVisitor : IVisitor
    {
        public void Visit(Bear bear)
        {
            System.Console.WriteLine("Bear has damaged the player");
        }

        public void Visit(Wolf wolf)
        {
            System.Console.WriteLine("Wolf has damaged the player");
        }
    }
}
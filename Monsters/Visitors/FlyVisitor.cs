namespace ComputerGame.Monsters.Visitors;

public class FlyVisitor : IVisitor {
    public void Visit(Bear bear)
    {
        System.Console.WriteLine("Bear is flying!");
    }

     public void Visit(Wolf wolf)
    {
        System.Console.WriteLine("Wolf is flying!");
    }
}
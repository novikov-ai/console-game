using System;
using System.Collections.Generic;

using ComputerGame.Monsters;
using ComputerGame.Monsters.Visitors;

namespace ComputerGame
{

    class Program
    {
        static void Main(string[] args){
            IVisitor attackVisitor = new AttackVisitor();
            IVisitor flyVisitor = new FlyVisitor();

            IMonster bear = new Bear(new Field(10,15));
            IMonster wolf = new Wolf(new Field(20,45));
            
            bear.AcceptVisitor(attackVisitor); // Bear has damaged the player
            bear.AcceptVisitor(flyVisitor); // Bear is flying!

            wolf.AcceptVisitor(attackVisitor); // Wolf has damaged the player
            wolf.AcceptVisitor(flyVisitor); // Wolf is flying!
        }
    }

    // OLD IMPLEMENTATION
    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         #region Preparing for the game
    //         Field field = new Field(30, 20);

    //         var players = new List<Player> { new Player("Alexander", field),
    //             new Player("Peter", field),
    //             new Player("Vasiliy", field)};

    //         var bonuses = new List<Bonus> { new Cherry(field),
    //             new Apple(field), new Apple(field), new Apple(field),
    //             new Banana(field),new Banana(field) };

    //         var monsters = new List<Monster> { new Bear(field),
    //             new Wolf(field),new Wolf(field) };

    //         var resources = new List<Resource> { new Stone(field), new Stone(field), new Stone(field), new Stone(field),
    //        new Tree(field),new Tree(field),new Tree(field),new Tree(field),new Tree(field) };
    //         #endregion

    //         #region:About the game
    //         Console.ForegroundColor = ConsoleColor.DarkYellow;

    //         Console.WriteLine($"There are {players.Count} players, {bonuses.Count} bonuses, {resources.Count} resources and {monsters.Count} monsters on the map!");
    //         foreach (Player human in players)
    //             human.GetPlayerInfo();

    //         Console.ForegroundColor = ConsoleColor.Cyan;
    //         Console.WriteLine(new string('-', 100));
    //         Console.WriteLine("Coordinates of all the objects on the field:");
    //         foreach (var obstacle in field.Obstacles)
    //             Console.WriteLine($"{obstacle.GetType()} X: {obstacle.PositionX} Y: {obstacle.PositionY}");
    //         #endregion

    //         #region: Movement phase
    //         Random random = new Random();
    //         var directions = new List<Player.Direction> { Player.Direction.Down, Player.Direction.Up,
    //             Player.Direction.Left, Player.Direction.Right };

    //         int moves = (monsters.Count + players.Count) * 10;
    //         while (moves > 0)
    //         {
    //             foreach (Player human in players)
    //             {
    //                 int direction = random.Next(0, 4);
    //                 human.Move(directions[direction]);
    //                 moves--;
    //             }

    //             foreach (Monster monster in monsters)
    //             {
    //                 monster.Move();
    //                 moves--;
    //             }
    //         }
    //         #endregion

    //         #region:Ending of the game
    //         Console.WriteLine(new string('-', 100));

    //         Console.ForegroundColor = ConsoleColor.DarkCyan;
    //         Console.WriteLine("Coordinates of all the objects on the field after the movement phase:");
    //         foreach (var obstacle in field.Obstacles)
    //             Console.WriteLine($"{obstacle.GetType()} X: {obstacle.PositionX} Y: {obstacle.PositionY}");

    //         Console.WriteLine(new string('-', 100));
    //         Console.ForegroundColor = ConsoleColor.DarkYellow;

    //         foreach (Player human in players)
    //             human.GetPlayerInfo();

    //         int bonusesLeft = 0;
    //         foreach (var item in field.Obstacles)
    //         {
    //             if (item is Bonus)
    //             {
    //                 bonusesLeft++;
    //             }
    //         }

    //         Console.WriteLine($"There are only {bonusesLeft} bonuses left on the map!");

    //         Player winner = null;
    //         foreach (Player survivor in players)
    //         {
    //             if (!survivor.Alive)
    //                 continue;

    //             if (winner is null)
    //             {
    //                 winner = survivor;
    //                 continue;
    //             }

    //             if (survivor.ScorePoints > winner.ScorePoints)
    //                 winner = survivor;

    //         }
    //         #endregion

    //         #region:Winner of the game
    //         if (winner != null)
    //         {
    //             Console.ForegroundColor = ConsoleColor.Green;
    //             Console.WriteLine($"The winner of the game is {winner.Name} with {winner.ScorePoints} score points!");
    //         }

    //         else
    //         {
    //             Console.ForegroundColor = ConsoleColor.DarkRed;
    //             Console.WriteLine("The game is winner!");
    //         }
    //         #endregion

    //         Console.ReadKey();
    //     }
    // }
}
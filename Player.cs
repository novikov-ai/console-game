using System;
using System.Collections.Generic;

namespace ComputerGame
{
    public class Player : Obstacle
    {
        public string Name;
        public int ScorePoints = 0;
        public bool Alive = true;
        public Player(string name, Field field) : base(field)
        {
            if (name is null)
                throw new ArgumentNullException("Argument input is null");

            Name = name;
        }

        public void GetPlayerInfo()
        {
            if (Alive)
                Console.WriteLine($"{Name} has {ScorePoints} score points!");
            else
                Console.WriteLine($"{Name} was eaten by the monster...");
        }

        public void Move(Direction direction)
        {
            int oldPosition = PositionX;
            bool directionX = true;

            switch (direction)
            {
                case Direction.Right:
                    {
                        PositionX = PositionX + 1 <= _field.Width ? PositionX + 1 : PositionX;
                        break;
                    }

                case Direction.Left:
                    {
                        PositionX = PositionX - 1 > 0 ? PositionX - 1 : PositionX;
                        break;
                    }

                case Direction.Up:
                    {
                        oldPosition = PositionY;
                        directionX = false;
                        PositionY = PositionY + 1 <= _field.Height ? PositionY + 1 : PositionY;
                        break;
                    }

                case Direction.Down:
                    {
                        oldPosition = PositionY;
                        directionX = false;
                        PositionY = PositionY - 1 > 0 ? PositionY - 1 : PositionY;
                        break;
                    }
            }

            foreach (var obstacle in _field.Obstacles)
            {
                if (obstacle is Bonus bonus && TryPick(bonus))
                {
                    return;
                }

                if (obstacle is Monster monster && monster.CanAtack(this))
                {
                    Alive = false;
                    return;
                }

                if (obstacle.DoesIntersect(this))
                {
                    if (directionX)
                        PositionX = oldPosition;
                    else
                        PositionY = oldPosition;
                    return;
                }
            }
        }

        public bool TryPick(Bonus bonus)
        {
            Obstacle obstacle = bonus as Obstacle;

            if (Math.Abs(PositionX - obstacle.PositionX) <= bonus.CollectionArea &&
                 Math.Abs(PositionY - obstacle.PositionY) <= bonus.CollectionArea)
            {
                bonus.RemoveBonus(this);
                return true;
            }
            return false;
        }

        public enum Direction
        {
            Right,
            Left,
            Up,
            Down
        }
    }
}
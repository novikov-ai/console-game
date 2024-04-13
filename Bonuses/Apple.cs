namespace ComputerGame
{
    public class Apple : Bonus
    {
        public override int ScorePoints => 3;
        public override int CollectionArea => 3;
        public Apple(Field field) : base(field){}
    }
}
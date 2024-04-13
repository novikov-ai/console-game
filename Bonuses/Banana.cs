namespace ComputerGame
{
    public class Banana : Bonus
    {
        public override int ScorePoints => 5;
        public override int CollectionArea => 2;
        public Banana(Field field) : base(field){}
    }
}
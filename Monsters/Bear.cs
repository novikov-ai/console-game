namespace ComputerGame
{
    public class Bear : Monster
    {
        public override int AttackRadius => 5;
        public override int Speed => 3;

        public override int Damage => 15;

        public Bear(Field field) : base(field) { }

        public override void Attack()
        {
            System.Console.WriteLine("Bear has damaged the player");
        }
    }
}
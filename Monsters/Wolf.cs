namespace ComputerGame
{
    public class Wolf : Monster
    {
        public override int AttackRadius => 3;
        public override int Speed => 5;
        public override int Damage => 7;

        public Wolf(Field field) : base(field) { }

        public override void Attack()
        {
            System.Console.WriteLine("Wolf has damaged the player");
        }
    }
}
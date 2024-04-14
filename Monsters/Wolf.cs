using ComputerGame.Monsters.Visitors;

namespace ComputerGame.Monsters
{
    public class Wolf : Monster, IMonster
    {
        public override int AttackRadius => 3;
        public override int Speed => 5;
        public override int Damage => 7;

        public Wolf(Field field) : base(field) { }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
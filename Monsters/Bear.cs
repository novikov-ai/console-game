using ComputerGame.Monsters.Visitors;

namespace ComputerGame.Monsters
{
    public class Bear : Monster, IMonster
    {
        public override int AttackRadius => 5;
        public override int Speed => 3;

        public override int Damage => 15;

        public Bear(Field field) : base(field) { }
        
        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
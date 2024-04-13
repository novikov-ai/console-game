using System;

namespace ComputerGame
{
    public class Tree : Resource
    {
        public Tree(Field field) : base(field) { }

        public override string GetResource()
        {
            return "1 pack of wood";
        }
    }
}
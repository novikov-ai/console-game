namespace VisitorsWithMixin
{
    public interface IBuilder
    {
        public bool Build(Func<bool> builder)
        {
            return builder.Invoke();
        }

        public virtual void Display()
        {
            System.Console.WriteLine("Displaying by default");
        }
    }

    public class Contractor : IBuilder
    {
        public void Build()
        {
            System.Console.WriteLine("Building in progress...");
        }
    }
}
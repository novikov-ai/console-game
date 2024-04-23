namespace VisitorsWithMixin
{
    public interface IBuilder
    {
        public bool Build(Func<bool> builder)
        {
            return builder.Invoke();
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
namespace VisitorsWithMixin
{
    public static class StringExtension
    {
        public static void Display(this string text)
        {
            System.Console.WriteLine($"Displaying: {text}!");
        }

        public static int CountWords(this string text)
        {
            return text.Split(" ").Length;
        }
    }
}
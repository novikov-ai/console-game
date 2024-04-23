# Паттерн Посетитель с примесями (Visitor with mix-in)

Для реализации механизма примесей C# позволяет использовать методы "расширения".

Например, определим статичный класс с новыми методами для объекта `String`:
~~~C#
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
~~~

Мы расширили стандартный класс `String` **закрытый для модификации** новой функциональностью! Работа с примесями происходит точно также, как и с обычными методами класса, для обычного пользователя разницы нет:

~~~C#
class Program
{
    static void Main(string[] args)
    {
        var helloWorld = "hello world";
        helloWorld.Display(); // Displaying: hello world!

        System.Console.WriteLine(helloWorld.CountWords()); // 2
    }
}
~~~

Начиная с версии C# 8.0, в язык была добавлена возможность реализовать интерфейс по умолчанию, который позволяет расширять класс новой функциональностью, тем самым реализовывая механизм "примесей".

~~~C#
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
~~~

~~~C#
class Program
{
    static void Main(string[] args)
    {
        IBuilder contractor = new Contractor();
        contractor.Build(() => "current status" == "ready");
    }
}
~~~
# Реализация паттерна Посетитель (Visitor)

### Версия 1.0 ("неистинное" наследование)

В данном примере преобладает "неистинное" наследование за счет родительского класса `Monster`. В первоначальной версии у нас был интерфейс `IMonster`, который являлся формальной спецификацией для наших классов. 

Расширение функционала доступно расширением спецификации `IMonster` и добавлением имплементации для каждого производного класса. 

~~~C#
class Program
{
    static void Main(string[] args){
        IMonster bear = new Bear(new Field(10,15));
        IMonster wolf = new Wolf(new Field(20,45));
        
        bear.Attack(); // Bear has damaged the player
        bear.Fly(); // Bear is flying!

        wolf.Attack(); // Wolf has damaged the player
        wolf.Fly(); // Wolf is flying!
    }
}
~~~

~~~C#
public interface IMonster
{
    public void Attack ();
    public void Fly ();
}

public abstract class Monster : Obstacle, IMonster
{
    // ...

    public virtual void Attack()
    {
        System.Console.WriteLine("Monster attacks");
    }

    public virtual void Fly()
    {
        System.Console.WriteLine("Monster flyies");
    }
}
~~~

~~~C#
public class Bear : Monster
{
    // ...
    
    public override void Attack()
    {
        System.Console.WriteLine("Bear has damaged the player");
    }

    public override void Fly()
    {
        System.Console.WriteLine("Bear is flying!");
    }
}
~~~

~~~C#
public class Wolf : Monster
{
    // ...
    
    public override void Attack()
    {
        System.Console.WriteLine("Wolf has damaged the player");
    }

    public override void Fly()
    {
        System.Console.WriteLine("Wolf is flying!");
    }
}
~~~

### Версия 2.0 ("истинное" наследование)

Использовав паттерн проектирования "Посетитель", изменил дизайн классов:

- Добавил интерфейс `IVisitor`, который позволяет "навещать" или вызывать определенный функционал для конкретного типа. 
- Добавил новые функции, которые унаследовал от `IVisitor`: `FlyVisitor` и `AttackVisitor`
- Также в интерфейс `IMonster`, описывающий базовый класс `Monster` добавил метод `AcceptVisitor()`, принимающий тип `IVisitor`. 
- Так как базовый класс `Monster` - абстрактный, то для каждого из производных `Bear` и `Wolf` написал реализацию `AcceptVisitor()`. 

Несмотря на то, что при использовании паттерна (версия 2.0) нужно написать больше кода, мы получаем большую гибкость и следующие преимущества:
- Мы можем расширять классы `Wolf`, `Bear` новым функционалом, не изменяя их непосредственно, то есть получаем преимущества рантайма
- Нам проще становится организовать кодовую базу, расширяя ее вширь, а не вглубь

Очевидно, что у данного подхода есть свои преимущества и недостатки. Многое зависит от специфики и дизайна проекта и, например, если у нас иерархия не такая плоская, а более сложная, то данный подход может не подойти. 

~~~C#
class Program
{
    static void Main(string[] args){
        IVisitor attackVisitor = new AttackVisitor();
        IVisitor flyVisitor = new FlyVisitor();

        IMonster bear = new Bear(new Field(10,15));
        IMonster wolf = new Wolf(new Field(20,45));
        
        bear.AcceptVisitor(attackVisitor); // Bear has damaged the player
        bear.AcceptVisitor(flyVisitor); // Bear is flying!

        wolf.AcceptVisitor(attackVisitor); // Wolf has damaged the player
        wolf.AcceptVisitor(flyVisitor); // Wolf is flying!
    }
}
~~~

~~~C#
public interface IVisitor
{
    public void Visit (Bear bear);
    public void Visit (Wolf wolf);
}
~~~

~~~C#
public class FlyVisitor : IVisitor 
{
    public void Visit(Bear bear)
    {
        System.Console.WriteLine("Bear is flying!");
    }

     public void Visit(Wolf wolf)
    {
        System.Console.WriteLine("Wolf is flying!");
    }
}
~~~

~~~C#
public class AttackVisitor : IVisitor
{
    public void Visit(Bear bear)
    {
        System.Console.WriteLine("Bear has damaged the player");
    }

    public void Visit(Wolf wolf)
    {
        System.Console.WriteLine("Wolf has damaged the player");
    }
}
~~~

~~~C#
public interface IMonster
{
    public void AcceptVisitor(IVisitor visitor);
}

public abstract class Monster : Obstacle, IMonster
{
    // ...
    
    public virtual void AcceptVisitor(IVisitor visitor) { }
}
~~~

~~~C#
public class Wolf : Monster
{
    // ... 

    public override void AcceptVisitor(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
~~~

~~~C#
public class Bear : Monster, IMonster
{
    // ... 

    public override void AcceptVisitor(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
~~~
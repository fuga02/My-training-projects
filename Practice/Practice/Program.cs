
Console.WriteLine();

var nimadir = new Voris();
nimadir.Display();
abstract class Tayanch
{
    public abstract void Display();
}

 class Voris : Tayanch
{
    public override void Display()
    {
        Console.WriteLine("Bu voris");
    }
}



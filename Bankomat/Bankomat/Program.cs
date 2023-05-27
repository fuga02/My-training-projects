var money = 100000;
Menu();

void Menu()
{
    Console.WriteLine("Bankomatga xushkelibsiz");
    Console.WriteLine("Menu : ");
    Console.WriteLine("1 : Hisobni ko'rish");
    Console.WriteLine("2 : Pul o'tkazmalari");
    Console.WriteLine("3 : Dastur xaqida");
    Console.Write(">>>");
    var input = Console.ReadLine();
    if (input == "1")
    {
        Account();
    }
    else if (input == "2")
    {
        TransferMoney();
    }
    else if (input == "3")
    {
        About();
    }
    else
    {
        Menu();
    }
}


void Account()
{
    Console.WriteLine($"Sizning balansingizda {money}so'm pul bor");
}

void TransferMoney()
{
    Console.Write("Karta raqamini kiriting >>>");
    var number = Console.ReadLine();
    Console.Write("O'tkazmoqchi bo'lgan miqdorizni kiriting >>>");
    var payment = int.Parse(Console.ReadLine()!);
    char c;
    Console.WriteLine($"{number} karta raqamiga {payment} qiymatdagi o'tkazmani tasdiqlaysizmi ?");
    Console.WriteLine("Y/N >>>");
    c = char.Parse(Console.ReadLine()!);
    if (c == 'Y')
    {
        Console.WriteLine("Tulov muvaqqiyatli amalga oshirildi :)");
    }
    else
    {
        Console.WriteLine("O'tkazma bekor qilindi :(");
    }
}

void About()
{
    Console.WriteLine("This project was created by Maruf in order to explain this kinda project to Algorithm CS group");
}

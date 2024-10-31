using GildedRose.UserInterface;

namespace GildedRose;

public abstract class Program
{
    public static void Main()
    {
        Console.WriteLine(Text.Messages.Welcome);
        while (Ui.UserInput != "exit")
        {
            Console.WriteLine(Text.Instructions.MainMenu);
            Ui.HandleUserInput();
        }
    }
}
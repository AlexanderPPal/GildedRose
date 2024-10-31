using GildedRose.UserInterface;

namespace GildedRose;

public abstract class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to the Gilded Rose!");
        while (Ui.UserInput != "exit")
        {
            Ui.PrintInstructions();
            Ui.HandleUserInput();
        }
    }
}
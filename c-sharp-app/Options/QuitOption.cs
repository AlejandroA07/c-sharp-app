namespace c_sharp_app.Options;

internal class QuitOption : IOption
{
    public string Name => "Avsluta";

    public void Run(AppContext context)
    {
        Console.WriteLine("Programm avslutas!");
        Console.WriteLine("Tryck Enter för att avsluta programmet!");
        Console.ReadKey();
        context.RequestHalt();
    }
}


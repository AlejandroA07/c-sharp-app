namespace c_sharp_app;
internal class Menu : IOption
{
    private int _selectedOptionIndex;
    private static readonly string CursorStrOn = "◄►";
    private static readonly string CursorStrOff = new string(' ', CursorStrOn.Length);


    public string Name { get; }
    public IOption[] Options { get; }
    public Menu? Parent { get; }

    public Menu(string name, params IOption[] options)
    {
        Name = name;
        Options = options;
    }

    public void Run(AppContext context)
    {
        context.MenuStack.Push(this);
        Console.Clear();
        DisplayMenu();
        

        while (!context.HaltRequested)
        {
            // Console.Clear();
            Console.CursorVisible = false;

            // DisplayMenu();

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Options[_selectedOptionIndex].Run(context);
                continue;
            }

            if (keyPressed.Key == ConsoleKey.DownArrow)
            {
                MoveCursor(1);
                continue;
            }
            if (keyPressed.Key == ConsoleKey.UpArrow)
            {
                MoveCursor(-1);
                continue;
            }
        }

        context.MenuStack.Pop();
    }

    private void DisplayMenu()
    {

        for (int i = 0; i < Options.Length; i++)
        {
            var isChosen = i == _selectedOptionIndex;
            var arrow = isChosen ? CursorStrOn : CursorStrOff;
            Console.WriteLine("{1}{0}", Options[i].Name, arrow);
        }
    }

    private void MoveCursor(int offset)
    {
        var newPosition = (_selectedOptionIndex + offset + Options.Length) % Options.Length;

        Console.SetCursorPosition(0, _selectedOptionIndex);
        Console.Write(CursorStrOff);
        Console.SetCursorPosition(0, newPosition);
        Console.Write(CursorStrOn);

        _selectedOptionIndex = newPosition;
    }
}

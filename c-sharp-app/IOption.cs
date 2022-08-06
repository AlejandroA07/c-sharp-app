namespace c_sharp_app;

internal interface IOption
{
    string Name { get; }
    void Run(AppContext context);
}



namespace c_sharp_app;

internal class AppContext
{
    public bool HaltRequested { get; private set; }

    public IStorage<Car> CarsStorage { get; set; }
    public IStorage<Person> PersonsStorage { get; set; }
    public IStorage<Staff> StaffStorage { get; set; }
    public IStorage<ServiceDate> RepareDateStorage { get; set; }

    public Stack<Menu> MenuStack { get; } = new ();

    public void RequestHalt () => HaltRequested = true;

}



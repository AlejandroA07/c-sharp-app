// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using c_sharp_app.Options;
using c_sharp_app.Storage;

namespace c_sharp_app;

class Program
{
    public static void Main(string[] args)
    {
        var menu = InitMenu();
        var context = InitContext();

        DisplaWelcomeMessage();
        menu.Run(context);
    }

    private static void DisplaWelcomeMessage()
    {
        Console.WriteLine("Välkommen!\nTryck Enter för att komma åt menyn!");
        Console.ReadKey();
    }

    private static AppContext InitContext()
    {
        var context = new AppContext();
        context.CarsStorage = new FlatFileStorage<Car>("./cars.json");
        return context;
    }

    private static Menu InitMenu()
    {
        var menu = new Menu(
            "MainMenu",
            new Menu(
                "Registrera Köpare",
                new RegisterBuyer(),
                new PrintBuyers(),
                new GoBackOption()
            ),
            new Menu(
                "Hantera Bilar",
                new StoreCarInfo(),
                new ListCars(),
                new GoBackOption()
            ),
            new Menu(
                "Service och Reparationer",
                new ServiceOption(),
                new ServiceHistory(),
                new GoBackOption()
            ),
            new Menu(
                "Hantera Personal",
                new StaffOption(),
                new ListStaff(),
                new GoBackOption()
            ),
            new QuitOption()
        );
        return menu;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace c_sharp_app.Options;

internal class PrintBuyers : IOption
{
    public string Name => "Visa köparen";

    public void Run(AppContext context)
    {
        foreach (var person in context.PersonsStorage.GetAll())
        {
            PrintCar(person);
        }

        Console.Write("Press any key to continue");
        Console.ReadKey(true);
    }

    private void PrintCar(Person person)
    {
        Console.WriteLine(JsonSerializer.Serialize(person));
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace c_sharp_app.Options;

internal class ListCars : IOption
{
    public string Name => "Visa lagrade bilar";

    public void Run(AppContext context)
    {
        foreach (var staff in context.StaffStorage.GetAll())
        {
            PrintCar(staff);
        }

        Console.Write("Press any key to continue");
        Console.ReadKey(true);
    }

    private void PrintCar(Staff staff)
    {
        Console.WriteLine(JsonSerializer.Serialize(staff));
    }
}


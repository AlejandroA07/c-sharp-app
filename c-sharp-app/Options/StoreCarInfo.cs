using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_app.Options;

internal class StoreCarInfo : IOption
{
    public string Name => "Lagra bil info";



    public void Run(AppContext context)
    {
        if (!TryReadCar(out var car))
            return;

        context.CarsStorage.Add(car);
        context.CarsStorage.Persist();
    }

    private bool TryReadCar(out Car car)
    {
        var cancelled = false;
        Console.CursorVisible = true;

        car = new Car()
        {
            Brand = ReadString("Vilket bilmärke? ", ref cancelled),
            Model = ReadString("Vilket modellbeteckning? ", ref cancelled),
            Year = ReadInt("Hur långt har den gått? ", "fel format, skriv in i rätt format", ref cancelled),
            KmDrived = ReadInt("Vilket årsmodell? ", "fel format, skriv in i rätt format", ref cancelled)
        };

        return !cancelled;
    }

    private int ReadInt(string message, string errorMsg, ref bool cancelled)
    {
        while (!cancelled)
        {
            Console.Write(message);
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                cancelled = true;
                break;
            }

            if (int.TryParse(input, out var value))
                return value;

            Console.WriteLine(errorMsg);
        }
        return 0;
    }
    string ReadString(string message, ref bool cancelled)
    {
        if (cancelled)
            return string.Empty;

        Console.Write(message);
        var strRead = Console.ReadLine() ?? string.Empty;
        cancelled = strRead == string.Empty;
        return strRead;
    }
}


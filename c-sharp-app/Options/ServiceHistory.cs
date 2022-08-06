using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace c_sharp_app.Options;
internal class ServiceHistory : IOption
{
    public string Name => "Visa lagrade Service och reparationer";

    public void Run(AppContext context)
    {
        foreach (var serviceDate in context.RepareDateStorage.GetAll())
        {
            PrintService(serviceDate);
        }

        Console.Write("Press any key to continue");
        Console.ReadKey(true);
    }
    private void PrintService(ServiceDate serviceDate)
    {
        Console.WriteLine(JsonSerializer.Serialize(serviceDate));
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace c_sharp_app.Options;
internal class ListStaff : IOption
{
    public string Name => "Visa Personal";

    public void Run(AppContext context)
    {
        foreach (var staff in context.StaffStorage.GetAll())
        {
            PrintStaff(staff);
        }

        Console.Write("Press any key to continue");
        Console.ReadKey(true);
    }
    private void PrintStaff(Staff staff)
    {
        Console.WriteLine(JsonSerializer.Serialize(staff));
    }
}


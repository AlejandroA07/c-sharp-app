using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_app.Options;
internal class StaffOption : IOption
{
    public string Name => "Hantera Personal";

    public void Run(AppContext context)
    {
        if (!TryReadStaff(out var staff))
            return;

        context.StaffStorage.Add(staff);
        context.StaffStorage.Persist();
    }


    private bool TryReadStaff(out Staff staff)
    {
        var cancelled = false;
        Console.CursorVisible = true;

        staff = new Staff()
        {
            EmployeeName = ReadString("Namn på anstäld person? ", ref cancelled),
            EmployeeLastName = ReadString("Efternamn på anstäld person? ", ref cancelled),
            EmployeeOcupation = ReadString("Den anstäld huvud uppgift? ", ref cancelled),
            EmployeePhoneNum = ReadInt("Telefonnummer? ", "fel format, skriv in i rätt format", ref cancelled)
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



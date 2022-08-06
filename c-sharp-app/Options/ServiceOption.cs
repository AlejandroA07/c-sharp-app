using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_app.Options;
using c_sharp_app.Storage;

namespace c_sharp_app.Options
{
    internal class ServiceOption : IOption
    {
        public string Name => "Boka tid för service eller reparation";

        public void Run(AppContext context)
        {
            if (!TryReadPerson(out var serviceDate))
                return;

            context.RepareDateStorage.Add(serviceDate);
            context.RepareDateStorage.Persist();
        }
        private bool TryReadPerson(out ServiceDate serviceDate)
        {
            var cancelled = false;
            Console.CursorVisible = true;

            serviceDate = new ServiceDate()
            {
                Task = ReadString("Vad vill du göra, reparera eller service? ", ref cancelled),
                Date = ReadString("Vilken datum? ", ref cancelled),
                NameAndCar = ReadString("skriv ditt namn och bil märke? ", ref cancelled),
                PhoneNum = ReadInt("Telefonnummer? ", "fel format, skriv in i rätt format", ref cancelled),
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
}

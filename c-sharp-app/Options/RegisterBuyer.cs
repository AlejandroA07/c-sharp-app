using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_app.Options
{
    internal class RegisterBuyer : IOption
    {
        public string Name => "Registrera Köpare";

        public void Run(AppContext context)
        {
            if (!TryReadPerson(out var person))
                return;

            context.PersonsStorage.Add(person);
            context.PersonsStorage.Persist();
        }
        private bool TryReadPerson(out Person person)
        {
            var cancelled = false;
            Console.CursorVisible = true;

            person = new Person()
            {
                FirstName = ReadString("Namn? ", ref cancelled),
                LastName = ReadString("Efternamn? ", ref cancelled),
                PhoneNumber = ReadInt("Telefonnummer? ", "fel format, skriv in i rätt format", ref cancelled),
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_app.Options
{
    internal class GoBackOption : IOption
    {
        public string Name { get; }

        public GoBackOption(string name = "Go Back")
        {
            Name = name;
        }

        public void Run(AppContext context)
        {
            context.MenuStack.Pop();
            context.MenuStack.Peek().Run(context);
        }
    }
}

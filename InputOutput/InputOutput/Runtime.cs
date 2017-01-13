using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputOutput
{
    class Runtime
    {
        public void Start()
        {
            var manager = new Manager();
            manager.CreateOrGetFile();
            manager.AskForInputAndPrintResults();
            manager.SaveToFile();
        }
    }
}

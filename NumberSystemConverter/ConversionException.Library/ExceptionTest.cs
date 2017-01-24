using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionException.Library
{
    public class ExceptionTest : System.Exception
    {
        public string ExceptionMessage { get; set; }
        public ExceptionTest(string message)
        {
            ExceptionMessage = "Invalid input: " + message;
        }
        public override string Message
        {
            get
            {
                return ExceptionMessage;
            }
        }
    }
}

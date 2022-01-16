using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Conversation_1._0.Validations
{
    public static class Validations
    {

        public static void ElementIsNull(IWebElement? el, bool expectedNull)
        {
            if (el == null && expectedNull)
                return;
            else if (el != null && expectedNull)
                throw new Exception("the element is not null but expected to be null");
            else if (el != null && !expectedNull)
                return;
            else if (el == null && !expectedNull)
                throw new Exception("the element is null but expected to be not null");
            else
                throw new Exception("You shouldnt be reading this message - Function name ElementIsNull");
        }


        public static bool StringCompare(string excepeted, string actual)
        {
            return 
                 excepeted.Equals(actual);
        }
        
        public static bool DateCompare(DateTime excepeted, DateTime actual)
        {
            return 
                 excepeted.Equals(actual);
        }
    }
}

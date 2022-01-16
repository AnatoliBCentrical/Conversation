using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation_1._0.LoginBase_And_Repo
{
    public class InterfaceClass
    { 
    public interface Interface1
    {
        void Method1()
            {
                Console.WriteLine("Hello");
            }
    }
        public interface Interface2
        {
            void Method2()
            {
                Console.WriteLine(" World");
            }
        }
    public class Class1 : Interface1
    {
        public void Method1()
        {
        }
    }
    public class Class2 : Interface2
    {
        public void Method2()
        { }
    }
    }
}

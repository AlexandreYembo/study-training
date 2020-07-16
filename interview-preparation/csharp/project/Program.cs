using System;
using project.Delegates;
using project.Extensions;
using project.iterators;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
           //new YieldReturn().Start();
           //new DelegatesImplements().Process();
            new ExtensionVsInstanceImplementation().TestMethods();
        }
    }
}

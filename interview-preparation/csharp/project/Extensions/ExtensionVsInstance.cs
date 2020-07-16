using System;

namespace project.Extensions
{
    /// <summary>
    /// This example will show when you have the same method name used in Extension class and in class that is instanced by the client.
    /// </summary>
    /// 
    
    public static class ExtensionTest
    {
        public static void Test(this string value){
            Console.WriteLine("Method called from extension: ");
        }
    }

    public class NormalClass
    {
        public void Test(){
            Console.WriteLine("Method overrided by the instance of the Object");
        }
    }

    public class ExtensionVsInstanceImplementation
    {
        public void TestMethods(){
            var text = "Test123";
            text.Test();

            var myClass = new NormalClass();
            myClass.Test();
        }
    }
}
using System;
using System.Collections.Generic;

namespace hackerrank{
public static class Instance {
        #region Factory
        //Create instance for a specific class defined on input of the program.
        private static ICode GetInstance(this string objTypeName) => (ICode) Activator.CreateInstance(Type.GetType("hackerrank." + objTypeName));

        #endregion

        public static void Run(string action) => GetInstance(action).Run();
    }
}
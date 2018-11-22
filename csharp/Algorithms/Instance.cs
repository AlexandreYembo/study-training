using System.Collections.Generic;

namespace hackerrank{
public static class Instance {
        #region Factory

        private static readonly IDictionary<Actions, ICode> INSTANCE = new Dictionary<Actions, ICode>
        {
            {Actions.SolveMeFirst, new SolveMeFirst()},
            {Actions.DiagonalDifference, new DiagonalDifference()},
        };

        private static ICode GetInstance(this Actions action) => INSTANCE.ContainsKey(action) ? INSTANCE[action] : null;

        #endregion

        public static void Run(Actions action) => GetInstance(action).Run();
    }
}
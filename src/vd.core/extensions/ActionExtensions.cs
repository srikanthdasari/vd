using System;

namespace vd.core.extensions
{
    public static class ActionExtensions
    {
        public static void Call(this Action action)
        {
            if (action.IsNotNull()) action();
        }

        public static void Call<T>(this Action<T> action, T param)
        {
            if (action.IsNotNull()) action(param);
        }

        public static void Call<T1, T2>(this Action<T1, T2> action, T1 param1, T2 param2)
        {
            if (action.IsNotNull()) action(param1, param2);
        }
    }
}
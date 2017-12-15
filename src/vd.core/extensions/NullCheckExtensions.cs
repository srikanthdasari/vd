using System;
namespace vd.core.extensions
{
    public static  class NullCheckExtensions
    {
          /// <summary>
        /// If Object is null return true else false.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }



        /// <summary>
        /// If Object is null return false else true
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }


        /// <summary>
        /// If T is null, call action, always return object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T IfNull<T>(this T obj, Action action)
        {
            if (obj.IsNull())
                action();
            return obj;
        }

        /// <summary>
        /// If T is null , return Func<TRet> 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TRet"></typeparam>
        /// <param name="obj"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TRet IfNull<T, TRet>(this T obj, Func<TRet> func) where TRet:class
        {
            return obj.IsNull() ? func() : obj as TRet;
        }


        /// <summary>
        /// If T is not Null, Call Action, always return object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T IfNotNull<T>(this T obj, Action action)
        {
            if (obj.IsNotNull())
                action();
            return obj;
        }

        /// <summary>
        /// If Object is not null, return Func<T, TR> else default(TR)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TR IfNotNull<T, TR>(this T obj, Func<T,TR> action)
        {
            return obj.IsNotNull() ? action(obj) : default(TR);
        }


        /// <summary>
        /// If T is not Null , return Func<T, TR> else default(TR)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TR IfNotNull<T,TR>(this T obj, Func<TR> action)
        {
            if (obj.IsNotNull())
                return action();
            return default(TR);
        }
    }
}
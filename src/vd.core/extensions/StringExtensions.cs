using System;
namespace vd.core.extensions
{
    public static  class StringExtensions
    {
        /// <summary>
        /// Retrun true if null or empty  else return false
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string val)
        {
            return string.IsNullOrEmpty(val);
        }

        /// <summary>
        /// Return true if not null or empty else return false
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string val)
        {
            return !string.IsNullOrEmpty(val);
        }

        /// <summary>
        /// Call Action() if string is Empty
        /// </summary>
        /// <param name="val"></param>
        /// <param name="act"></param>
        /// <returns>Always return the same string</returns>
        public static string IfEmpty(this string val, Action act)
        {
            if (val.IsEmpty())
                act();
            return val;
        }

        /// <summary>
        /// Call Action if string is Empty
        /// </summary>
        /// <param name="val"></param>
        /// <param name="act"></param>
        /// <returns>Always return the same string</returns>
        public static string IfEmpty(this string val, Func<string> act)
        {
            return val.IsEmpty() ? act() : val;
        }

        /// <summary>
        /// Call Action if string is not empty
        /// </summary>
        /// <param name="val"></param>
        /// <param name="act"></param>
        /// <returns>Always return the same string</returns>
        public static string IfNotEmpty(this string val, Action act)
        {
            if (val.IsNotEmpty())
                act();
            return val;
        }

        /// <summary>
        /// Call Action<string>() if string is not Empty
        /// </summary>
        /// <param name="val"></param>
        /// <param name="act"></param>
        /// <returns></returns>
        public static string IfNotEmpty(this string val, Action<string> act)
        {
            if (val.IsNotEmpty())
                act(val);
            return val;
        }

        /// <summary>
        /// Call Func<string, string>() if string is not empty 
        /// If not empty : return result from Func<string, string>
        /// If empty: return same
        /// </summary>
        /// <param name="val"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string IfNotEmpty(this string val, Func<string, string> action)
        {
            return val.IsNotEmpty() ? action(val) : val;
        }

        /// <summary>
        /// Call Func<string, TRet> if string is not empty
        /// If Not Empty : return result from Func<string, TRet>
        /// If empty: return same
        /// </summary>
        /// <typeparam name="TRet"></typeparam>
        /// <param name="val"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TRet IfNotEmpty<TRet>(this string val, Func<string, TRet> action)
        {
            return val.IsNotEmpty() ? action(val) : default(TRet);
        }


        /// <summary>
        /// Call Null Safe
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string Call(this Func<string> action)
        {
            return action.IsNull() ? string.Empty : action();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string IfNullEmptyStr(this string source)
        {
            return source.IsEmpty() ? string.Empty : source;
        }
    }
}
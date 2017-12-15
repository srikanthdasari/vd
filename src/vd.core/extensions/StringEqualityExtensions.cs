using System;
using System.Linq;
namespace vd.core.extensions
{
    public static  class StringEqualityExtensions
    {
        /// <summary>
        /// Are strings the same ? -  CurrentCultureIgnoreCase
        /// </summary>
        /// <param name="str"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsEqualTo(this string str, string val)
        {
            if (str.IsNull() && val.IsNull()) return true;
            if (str.IsNull() || val.IsNull()) return false;

            return str.Equals(val, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Are String Different ? - Current Culture Ignore case
        /// </summary>
        /// <param name="str"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNotEqualTo(this string str, string val)
        {
            if (str.IsNull() && val.IsNull()) return false;
            if (str.IsNull() || val.IsNull()) return true;

            return !str.Equals(val, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Execute action if strings are not equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string IfNotEqualTo(this string left, string right, Action<string, string> action)
        {
            if (left.IsNotEqualTo(right))
                action(left, right);

            return left;
        }


        /// <summary>
        /// Execute action if strings are not equal 
        /// </summary>
        /// <typeparam name="TRet"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="func"></param>
        /// <returns>Returns default(TRet) if string not equal, else Func<Tret>()</returns>
        public static TRet IfNotEqualTo<TRet>(this string left, string right, Func<string, string, TRet> func)
        {
            if (left.IsNotEqualTo(right))
                return func(left, right);

            return default(TRet);
        }

        /// <summary>
        /// Execute action if strings are equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="action"></param>
        /// <returns>Always return left string</returns>
        public static string IfEqualTo(this string left, string right, Action<string, string> action)
        {
            if (left.IsEqualTo(right))
                action(left, right);

            return left;
        }

        /// <summary>
        /// Execute Func if string are equal
        /// </summary>
        /// <typeparam name="TRet"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="func"></param>
        /// <returns>Return default(TRet) if string equal, else Func<TRet>()</returns>
        public static TRet IfEqualTo<TRet>(this string left, string right, Func<string, string, TRet> func)
        {
            if (left.IsEqualTo(right))
                return func(left, right);

            return default(TRet);
        }

        /// <summary>
        /// index of the string
        /// </summary>
        /// <param name="left"></param>
        /// <param name="choices"></param>
        /// <returns></returns>
        public static int IndexOfString(this string left, params string[] choices)
        {
            if (left.IsEmpty()) return -1;
            var idx = -1;
            return choices.Any(choice => 0 <= (idx = left.IndexOf(choice, StringComparison.OrdinalIgnoreCase))) ? idx : idx;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool StartsWithString(this string left, string right)
        {
            if (left.IsEmpty() || left.IsEmpty()) return false;

            return left.StartsWith(right, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="choices"></param>
        /// <returns></returns>
        public static bool ContainsString(this string left,params string[] choices)
        {
            return IndexOfString(left, choices) >= 0;
        }
    }
}
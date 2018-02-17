using System;
using System.Linq.Expressions;
using System.Reflection;

namespace vd.core
{
    
    [AttributeUsage(AttributeTargets.Property)]
    public class FeedOrderAttribute:Attribute
    {
        private int _order;


        public int Order
        {
            get { return _order; }
        }


        private Type _convertTo;

        public Type ConvertTo
        {
            get{ return _convertTo;}
        }

        public FeedOrderAttribute(int order)
        {
            this._order = order;            
        }

        public FeedOrderAttribute(int order, Type convertto)
        {
            this._order = order;            
            this._convertTo=convertto;
        }

    }
}
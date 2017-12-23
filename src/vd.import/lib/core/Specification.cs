using System;
using vd.import.lib.Interface;

namespace vd.import.lib.core
{
    public class Specification<T>:ISpecification<T>
    {
        private Func<T,bool> expression;

        public Specification(Func<T,bool> expression)
        {
            if(expression==null)
                throw new ArgumentNullException();
            else
                this.expression=expression;
        }

        public bool IsSatisfiedBy(T o)
        {
            return this.expression(o);
        }

    }
}
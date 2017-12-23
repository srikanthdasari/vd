using System;
using vd.core.extensions;
using vd.import.lib.Interface;

namespace vd.import.lib.core
{
    //public class TaskHandler<T>:IHandler<T> where T:IProcessable
    public class TaskHandler<T>:IHandler<T> where T:TaskContext
    {
        private IHandler<T> Successor;

        
        private Interface.ISpecification<T> specification;

        //Action<T> Action {get;set;}

        T Context {get;set;}

        public TaskHandler(ISpecification<T> _specification, T _taskContext)
        {
            specification=_specification;            
            Context=_taskContext;
        }

        public bool CanHandle(T o)
        {
            if(this.specification!=null&&o!=null)
            {
                return this.specification.IsSatisfiedBy(o);
            }

            return false;
        }


        public void SetSuccessor(IHandler<T> handler)
        {
            this.Successor=handler;
        }


        public void HandleRequest()
        {
            if(CanHandle(Context))
            {
                Console.WriteLine("{0}: Request Handled ",Context.GetType().ToString());
                Context.PerformTask();
                Console.WriteLine("************************************************");
            }
            if(this.Successor.IsNotNull())
            {
                this.Successor.HandleRequest();
            }
        }

        public void SetSpecification(Interface.ISpecification<T> specification)
        {
            this.specification=specification;
        }

        public IHandler<T> GetSuccessor()
        {
            Console.WriteLine("Get Successor :"+this.Successor.ToString());
            return this.Successor;
        }
    }
}
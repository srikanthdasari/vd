using System;
using System.Threading.Tasks;
using vd.core.extensions;
using vd.import.lib.constants;
using vd.import.lib.Interface;
namespace vd.import.lib.core
{
     public class Processable:IProcess
     {
        public Action Action {get;set;}

        public Processable(Action action)
        {
            Action=action;
        }

        public virtual void Process()
        {
            if(Action.IsNotNull())
                Action.Invoke();
        }
    }
}
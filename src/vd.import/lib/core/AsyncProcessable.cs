using System;
using System.Threading.Tasks;
using vd.core.extensions;

namespace vd.import.lib.core
{
    public class AsyncProcessable : Processable
    {
        public AsyncProcessable(Action action):base(action)
        {
            
        }

        public override async void Process()
        {
            await Task.Run(()=>{
                  if(Action.IsNotNull())
                 Action.Invoke();  
            });
        }
    }
}
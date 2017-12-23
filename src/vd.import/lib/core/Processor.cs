// using System;
// using System.Threading.Tasks;
// using vd.import.lib.constants;
// using vd.import.lib.Interface;
// namespace vd.import.lib.core
// {
//     public abstract class Processor:IProcess
//     {
        
//         #region  Members
//         public TaskContext TaskContext {get;set;}
//         public Guid ProcessID { get{ return Guid.NewGuid(); } }
//         protected Processor Next; 
//         public ProcessState ProcessState { get; set; }
//         #endregion

//         #region Constructor
//         public Processor(ProcessState processState)
//         {
//             ProcessState=processState;
//         }
//         #endregion

//         public Processor SetNext(Processor nextunit)
//         {
//             Next=nextunit;
//             return nextunit;
//         }

//         public void DoProcess(ProcessState processState)
//         {
//             //Dynamically chnaging the Object behaviour...Coudl be strategy? or Decorator
//             Task.PerformTask(processState);
            
//         }

//     }
// }
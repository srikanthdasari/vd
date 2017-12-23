namespace vd.import.lib.Interface
{
    public interface IHandler<T>
    {
        void SetSuccessor(IHandler<T> handler);
        void HandleRequest();        
        IHandler<T> GetSuccessor();
    } 
}
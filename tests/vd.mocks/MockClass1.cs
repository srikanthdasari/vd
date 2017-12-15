namespace vd.mocks
{
    public class MockClass1
    {
        public bool SomeMethodCalled = false;

        public void MethodReturnVoid()
        {
            SomeMethodCalled = true;
        }
    }
}
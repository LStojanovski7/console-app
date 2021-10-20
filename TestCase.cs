using System;

public class TestCase<T, E>
                // where T : Array
                // where E : Type
{
    public T[] Array { get; set; }
    public E ExpectedResult { get; set; }

    public TestCase(T[] _array, E _expectedResult)
    {
        Array = _array;
        ExpectedResult = _expectedResult;
    }
}
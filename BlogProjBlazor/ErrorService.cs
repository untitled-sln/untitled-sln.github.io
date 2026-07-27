using System;

public class ErrorService
{
    public Exception? Exception { get; private set; }

    public void SetError(Exception ex)
    {
        Exception = ex;
    }

    public void Clear()
    {
        Exception = null;
    }
}
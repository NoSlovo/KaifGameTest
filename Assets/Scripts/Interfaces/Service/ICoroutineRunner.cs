using System.Collections;

public interface ICoroutineRunner : IService
{
    void Run(IEnumerator coroutine);
}
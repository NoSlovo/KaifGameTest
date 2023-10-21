using System.Collections;
using Factory;
using Factory.BodyFactory;
using UnityEngine.SceneManagement;

public class LoadState : IState
{
    private Game _game;
    private ICoroutineRunner _coroutineRunner;

    public LoadState(Game game, ICoroutineRunner coroutineRunner)
    {
        _game = game;
        _coroutineRunner = coroutineRunner;
    }

    public void Enter()
    {
        _coroutineRunner.Run(LoadScen());
    }

    public void Exit()
    {
    }

    private IEnumerator LoadScen()
    {
        yield return Conteiner.instance.GetService<IFactoryApple>();
        yield return Conteiner.instance.GetService<IBodyFactory>();
        yield return Conteiner.instance.GetService<IPullService>();

        SceneManager.LoadSceneAsync(1);
    }
}
using Factory;
using Factory.BodyFactory;

namespace DefaultNamespace.Infrastructure.GameStateMashine.States
{
    public class InitializationState : IState
    {
        private Game _gameStateMashine;
        private Apple _applePrefab;
        private SnakeBody _bodyPrefab;
        private IFactoryApple _appleFactory;
        private IBodyFactory _bodyFactory;
        private IPullService _pullService;

        public InitializationState(Game gameStateMashine, Apple applePrefab, SnakeBody bodyPrefab)
        {
            _gameStateMashine = gameStateMashine;
            _applePrefab = applePrefab;
            _bodyPrefab = bodyPrefab;
        }

        public void Enter()
        {
            Conteiner.Initialaize();

            _appleFactory = new AppleFactory(_applePrefab);
            _bodyFactory = new BodyFactory(_bodyPrefab);

            Conteiner.instance.AddSerivese(_appleFactory);
            Conteiner.instance.AddSerivese(_bodyFactory);

            _pullService = new ApplePull();
            Conteiner.instance.AddSerivese(_pullService);

            _gameStateMashine.EnterState<LoadState>();
        }

        public void Exit()
        {
        }
    }
}
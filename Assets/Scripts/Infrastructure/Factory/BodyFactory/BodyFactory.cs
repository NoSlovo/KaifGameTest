using UnityEngine;

namespace Factory.BodyFactory
{
    public class BodyFactory : IBodyFactory
    {
        private SnakeBody _snakeBodyPrefab;

        public BodyFactory(SnakeBody prefab)
        {
            _snakeBodyPrefab = prefab;
        }

        public SnakeBody Create()
        {
            return GameObject.Instantiate(_snakeBodyPrefab);
        }
    }
}
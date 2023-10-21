using UnityEngine;


namespace Factory
{
    public class AppleFactory : IFactoryApple
    {
        private Apple _applePrefab;

        public AppleFactory(Apple applePrefab)
        {
            _applePrefab = applePrefab;
        }

        public Apple Create(FruitType type, Transform parent)
        {
            switch (type)
            {
                case FruitType.Apple:
                    return Object.Instantiate(_applePrefab, parent.position, Quaternion.identity, parent);
            }

            return null;
        }
    }
}
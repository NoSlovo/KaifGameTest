using System;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public class ApplePull : IPullService
    {
        private IFactoryApple _factory;
        private Queue<Apple> _fruits = new();
        private int _instanceAppleCount;
        public int InstanceAppleCount => _instanceAppleCount;
        public event Action ObjectDisable;

        public ApplePull()
        {
            _instanceAppleCount = 0;
            _factory = Conteiner.instance.GetService<IFactoryApple>();
        }

        public void CreatePullObjects(FruitType type, Transform parent, int countInstanceObject)
        {
            for (int i = 0; i < countInstanceObject; i++)
            {
                var fruit = _factory.Create(type, parent);
                fruit.Active(false);
                _fruits.Enqueue(fruit);
                _instanceAppleCount++;
            }
        }

        public void ReturnApple(Apple appleObject)
        {
            _fruits.Enqueue(appleObject);
            appleObject.Active(false);
            ObjectDisable?.Invoke();
        }

        public Apple GetFruit(FruitType type, Transform parent)
        {
            if (_instanceAppleCount == 0)
            {
                var fruit = _factory.Create(type, parent);
                fruit.Active(false);
                return fruit;
            }

            _instanceAppleCount--;
            return _fruits.Dequeue();
        }
    }
}
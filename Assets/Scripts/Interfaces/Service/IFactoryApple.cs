using System;
using UnityEngine;

namespace Factory
{
    public interface IFactoryApple : IService
    {
        public Apple Create(FruitType type,Transform parent);
    }
}
using System;
using UnityEngine;

namespace Factory
{
    public interface IPullService : ICreateObject,IReturnObjects
    {
       event Action ObjectDisable;
        public Apple GetFruit(FruitType type, Transform parent);
    }
}
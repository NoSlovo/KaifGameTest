using UnityEngine;

namespace Factory
{
    public interface ICreateObject : IService
    {
        public void CreatePullObjects(FruitType type, Transform parent,int CountInstance);
    }
}
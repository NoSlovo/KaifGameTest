using UnityEngine;

namespace Interfaces.Service
{
  public interface IInputService : IService
  {
    Vector2 Direction { get;}
  }
}
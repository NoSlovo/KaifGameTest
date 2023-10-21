using Interfaces.Service;
using UnityEngine;


public class InputUser : MonoBehaviour,IInputService
{
   [SerializeField] private DynamicJoystick _joystick;

   public Vector2 Direction => _joystick.Direction;
}
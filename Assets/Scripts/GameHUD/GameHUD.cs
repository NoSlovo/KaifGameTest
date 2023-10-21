using Interfaces.Service;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameHUD : MonoBehaviour
    {
        [SerializeField] private InputUser _inputUser;

        private void Awake()
        {
            Conteiner.instance.AddSerivese<IInputService>(_inputUser);
        }
    }
}
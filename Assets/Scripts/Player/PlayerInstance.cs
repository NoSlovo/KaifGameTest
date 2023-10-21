using System.Collections;
using Interfaces.Service;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
   [SerializeField] private Snake _snakePrefab;
   [SerializeField] private СameraFollow _сameraFollow;
   [SerializeField] private AppleSpawner _appleSpawner;

 
   private void Start()
   {
      StartCoroutine(InstancePlayer());
   }

   private IEnumerator InstancePlayer()
   {
      var input =  Conteiner.instance.GetService<IInputService>();

      while (input == null)
      {
         yield return null;
      }

      var player = Instantiate(_snakePrefab);
      player.InputService = input;
      player.transform.position = transform.position;
      player._appleSpawner = _appleSpawner;
      _сameraFollow.SetTarget(player);
   }
}

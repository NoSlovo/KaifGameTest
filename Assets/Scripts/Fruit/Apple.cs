using Factory;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private IPullService _pullService;

    private void Start() => _pullService = Conteiner.instance.GetService<IPullService>();

    public void Active(bool activeObject) => gameObject.SetActive(activeObject);

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Snake _snake))
        {
            _snake.Addbody();
            Active(false);
            _pullService.ReturnApple(this);
        }
    }
}
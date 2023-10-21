using System.Collections.Generic;
using DefaultNamespace.Snake;
using DG.Tweening;
using Factory.BodyFactory;
using Interfaces.Service;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Snake : MonoBehaviour
{
    public AppleSpawner _appleSpawner;
    private float _spead = 8f;
    private Rigidbody _rb;
    private Movement _moveSnake;
    private IBodyFactory _bodyFactory;
    private List<SnakeBody> _snakeBodies = new();
    private float _distance = 0.15f;
    private Vector3 _normal;

    public IInputService InputService;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _bodyFactory = Conteiner.instance.GetService<IBodyFactory>();
        _moveSnake = new Movement(_rb, transform, _spead);
    }

    private void Start()
    {
        Addbody();
    }

    private void OnCollisionStay(Collision other)
    {
        if (other == null)
        {
        }
    }

    private void FixedUpdate()
    {
        _moveSnake.Move(InputService.Direction,_normal,_appleSpawner.transform);
        BodyMove();
    }
    
    private void BodyMove()
    {
        float sqrDistance = _distance * _distance;
        Vector3 previusPostion = transform.position;
        
        foreach (var bodi in _snakeBodies)
        {
            if ((bodi.transform.position - previusPostion).sqrMagnitude > sqrDistance)
            {
                var tepm = bodi.transform.position;
                bodi.transform.position = previusPostion;
                bodi.transform.DOMove(previusPostion, _distance);
                previusPostion = tepm;
            }
            else
            {
                break;
            }
        }
    }

    public void Addbody()
    {
        var body = _bodyFactory.Create();
        _snakeBodies.Add(body);
    }
}
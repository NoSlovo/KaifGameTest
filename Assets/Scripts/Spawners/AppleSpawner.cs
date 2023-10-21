using System;
using System.Collections;
using Factory;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private FruitType _type;
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private int _offset = 13;
    [SerializeField] private int _instanceCount = 40;

    private IPullService _applePull;
    private FindingAPointOnAMesh _findingAPointOnAMesh;

    private void OnEnable()
    {
        _applePull = Conteiner.instance.GetService<IPullService>();
        _applePull.ObjectDisable += CreateAndSetPointFruit;
    }

    private void Awake()
    {
        _findingAPointOnAMesh = new FindingAPointOnAMesh(transform);
    }

    private void Start()
    {
        InstanceApple();
        StartCoroutine(ArrangeObjects());
    }

    private void InstanceApple() => _applePull.CreatePullObjects(_type, transform, _instanceCount);

    private IEnumerator ArrangeObjects()
    {
        for (int i = 0; i <= _instanceCount; i++)
        {
            CreateAndSetPointFruit();
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    private void CreateAndSetPointFruit()
    {
        var apple = _applePull.GetFruit(_type, transform);
        apple.transform.position = _findingAPointOnAMesh.GetPointOnMesh(_meshFilter.mesh);
        apple.transform.position -= (transform.position - apple.transform.position) / _offset;
        apple.Active(true);
    }

    private void OnDisable()
    {
        _applePull.ObjectDisable -= CreateAndSetPointFruit;
    }
}
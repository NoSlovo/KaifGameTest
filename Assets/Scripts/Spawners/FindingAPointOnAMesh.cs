using UnityEngine;

public class FindingAPointOnAMesh
{
    private Transform _transform;

    public FindingAPointOnAMesh(Transform transform)
    {
        _transform = transform;
    }

    public Vector3 GetPointOnMesh(Mesh mesh)
    {
        Vector3[] vertices = mesh.vertices;
        var randomPoint = Random.Range(0, vertices.Length);
        return _transform.localToWorldMatrix.MultiplyPoint3x4(mesh.vertices[randomPoint]);
    }
}
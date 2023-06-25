using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleGenerator : MonoBehaviour
{
    Mesh mesh;
    int[] pentagonIdx;
    int[] hexagonIdx;
    int[] squareIdx;
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        hexagonIdx = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 5, 0, 5, 6, 0, 6, 1 };
        pentagonIdx = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 5, 0, 5, 1, };
        squareIdx = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 1, };
    }
    public Vector3[] PolygonFunc(float radius, int vertex, float firstDegree)
    {
        Vector3[] node = new Vector3[vertex + 1];
        float deg = (360 - firstDegree) / (vertex - 1);

        node[0] = new Vector3(0, 0);
        for (int i = 1; i <= 2; i++)
        {
            var rad = Mathf.Deg2Rad * (firstDegree * (i - 1));
            var x = radius * Mathf.Sin(rad);
            var y = radius * Mathf.Cos(rad);
            node[i] = new Vector3(x, y);
        }
        for (int i = 3; i <= vertex; i++)
        {
            var rad = Mathf.Deg2Rad * ((deg * (i - 2)) + firstDegree);
            if (i == 1) rad = 0;
            var x = radius * Mathf.Sin(rad);
            var y = radius * Mathf.Cos(rad);
            node[i] = new Vector3(x, y);
        }
        return node;
    }

    public void createProceduralMesh(Vector3[] vertex)
    {
        mesh.Clear();

        mesh.vertices = vertex;

        if (vertex.Length == 7)
            mesh.triangles = hexagonIdx;
        else if (vertex.Length == 6)
            mesh.triangles = pentagonIdx;
        else if (vertex.Length == 5)
            mesh.triangles = squareIdx;
        mesh.RecalculateNormals();
    }
}

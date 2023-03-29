using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FullPolygon : MonoBehaviour
{
    Mesh mesh;
    Vector3[] Hexanode;
    Vector3[] Pentanode;
    Vector3[] Squarenode;
    int[] pentagonIdx;
    int[] hexagonIdx;
    int[] squareIdx;
    Material[] mts;
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        mts = GetComponent<Renderer>().materials;
        hexagonIdx = new int[] { 6, 0, 1, 6, 1, 2, 6, 2, 3, 6, 3, 4, 6, 4, 5, 6, 5, 0 };
        pentagonIdx = new int[] { 5, 0, 1, 5, 1, 2, 5, 2, 3, 5, 3, 4, 5, 4, 0 };
        squareIdx = new int[] { 4, 0, 1, 4, 1, 2, 4, 2, 3, 4, 3, 0 };
    }
    public Vector3[] Hexagon(float radius)
    {
        Hexanode = new Vector3[7];
        float deg = 60;

        for (int i = 0; i < 6; i++)
        {
            var rad = Mathf.Deg2Rad * (deg + 60 * i);
            var x = radius * Mathf.Sin(rad);
            var y = radius * Mathf.Cos(rad);
            Hexanode[i] = new Vector3(x, y);
        }
        Hexanode[6] = new Vector3(0, 0);
        return Hexanode;
    }
    public Vector3[] Pentagon(float radius)
    {
        Pentanode = new Vector3[6];
        float deg = 60;
        for (int i = 0; i < 5; i++)
        {
            var rad = Mathf.Deg2Rad * (deg + 72 * i);
            var x = radius * Mathf.Sin(rad);
            var y = radius * Mathf.Cos(rad);
            Pentanode[i] = new Vector3(x, y);
        }
        Pentanode[5] = new Vector3(0, 0);
        return Pentanode;
    }

    public Vector3[] Square(float radius)
    {

        Squarenode = new Vector3[5];
        float deg = 60;
        for (int i = 0; i < 4; i++)
        {
            var rad = Mathf.Deg2Rad * (deg + 90 * i);
            var x = radius * Mathf.Sin(rad);
            var y = radius * Mathf.Cos(rad);
            Squarenode[i] = new Vector3(x, y);
        }
        Squarenode[4] = new Vector3(0, 0);
        return Squarenode;
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

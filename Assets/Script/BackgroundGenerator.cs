using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundGenerator : MonoBehaviour
{
    Mesh mesh;

    int[] pentagonIdx1;
    int[] pentagonIdx2;
    int[] pentagonIdx3;

    int[] hexagonIdx1;
    int[] hexagonIdx2;

    int[] squareIdx1;
    int[] squareIdx2;

    Material[] mts;
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        mts = GetComponent<Renderer>().materials;
        hexagonIdx1 = new int[] { 0, 1, 2, 6, 7, 8, 12, 13, 14 };
        hexagonIdx2 = new int[] { 3, 4, 5, 9, 10, 11, 15, 16, 17 };
        pentagonIdx1 = new int[] { 3, 4, 5, 9, 10, 11 };
        pentagonIdx2 = new int[] { 6, 7, 8, 12, 13, 14 };
        pentagonIdx3 = new int[] { 0, 1, 2 };
        squareIdx1 = new int[] { 0, 1, 2, 6, 7, 8 };
        squareIdx2 = new int[] { 3, 4, 5, 9, 10, 11 };
    }



    public Vector3[] PolygonFunc(float radius, int vertex, float firstDegree)
    {
        Vector3[] node = new Vector3[vertex * 3];
        float deg = (360 - firstDegree) / (vertex - 1);

        node[0] = new Vector3(0, 0);
        for (int i = 1; i <= 2; i++)
        {
            var rad = Mathf.Deg2Rad * (firstDegree * (i - 1));
            var x = radius * Mathf.Sin(rad);
            var y = radius * Mathf.Cos(rad);
            node[i] = new Vector3(x, y);
        }

        for (int j = 1; j < vertex; j++)
        {
            node[j * 3] = new Vector3(0, 0);
            for (int i = 1; i <= 2; i++)
            {
                var rad = Mathf.Deg2Rad * ((deg * (j + i - 2)) + firstDegree);
                var x = radius * Mathf.Sin(rad);
                var y = radius * Mathf.Cos(rad);
                node[j * 3 + i] = new Vector3(x, y);
            }
        }

        return node;
    }

    public void createProceduralMesh(Vector3[] vertex)
    {
        mesh.Clear();

        mesh.vertices = vertex;

        if (vertex.Length == 18)
        {
            mesh.subMeshCount = 2;
            mesh.SetTriangles(hexagonIdx1, 0);
            mesh.SetTriangles(hexagonIdx2, 1);
        }
        if (vertex.Length == 15)
        {
            mesh.subMeshCount = 3;
            mesh.SetTriangles(pentagonIdx1, 0);
            mesh.SetTriangles(pentagonIdx2, 1);
            mesh.SetTriangles(pentagonIdx3, 2);
        }
        if (vertex.Length == 12)
        {
            mesh.subMeshCount = 2;
            mesh.SetTriangles(squareIdx1, 0);
            mesh.SetTriangles(squareIdx2, 1);
        }
        mesh.RecalculateNormals();
    }


}

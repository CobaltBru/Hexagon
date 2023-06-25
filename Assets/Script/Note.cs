using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Mesh mesh;
    public PolygonGenerator polygonGenerator;
    public GameManager gameManager;
    public int speed;
    Vector3[] point;
    Vector3[] outPoly;
    Vector3[] inPoly;
    Vector3 up1;
    Vector3 up2;
    Vector3 down1;
    Vector3 down2;
    int currentEdge;
    double boxSize;
    double len;
    int vertex;
    int currentLen;

    void Awake()
    {
        outPoly = new Vector3[6];
        inPoly = new Vector3[6];
        point = new Vector3[4];
        len = polygonGenerator.getLen();
        currentLen = 0;
        vertex = polygonGenerator.getCurrentPoly();
        init();
        
    }
    void Update()
    {
        


    }

    void calcNote(ref Vector3 p1, ref Vector3 p2)
    {
        p1 = Vector3.Lerp(p1, down1, Time.deltaTime);
        p2 = Vector3.Lerp(p2, down2, Time.deltaTime);
    }
    
    void callNote(int num, double boxSize)
    {
        currentEdge= num;
        this.boxSize = boxSize;
    }
    void calcPoint()
    {
        vertex = polygonGenerator.getCurrentPoly();
        float firstDegree = polygonGenerator.getfirstDegree();
        float radius1 = polygonGenerator.getOutRadius();
        float radius2 = polygonGenerator.getInRadius();
        float deg = (360 - firstDegree) / (vertex - 1);

        for (int i = 1; i <= 2; i++)
        {
            var rad = Mathf.Deg2Rad * (firstDegree * (i - 1));
            var x = radius1 * Mathf.Sin(rad);
            var y = radius1 * Mathf.Cos(rad);
            outPoly[i] = new Vector3(x, y);
            x = radius2 * Mathf.Sin(rad);
            y = radius2 * Mathf.Cos(rad);
            inPoly[i] = new Vector3(x, y);
        }
        for (int i = 3; i <= vertex; i++)
        {
            var rad = Mathf.Deg2Rad * ((deg * (i - 2)) + firstDegree);
            if (i == 1) rad = 0;
            var x = radius1 * Mathf.Sin(rad);
            var y = radius1 * Mathf.Cos(rad);
            outPoly[i] = new Vector3(x, y);
            x = radius2 * Mathf.Sin(rad);
            y = radius2 * Mathf.Cos(rad);
            inPoly[i] = new Vector3(x, y);
        }
    }
    void calcSquare()
    {
        up1 = outPoly[currentEdge];
        up2 = outPoly[(currentEdge + 1)%vertex];
        down1 = inPoly[currentEdge];
        down2 = inPoly[(currentEdge + 1)%vertex];
    }
    void init()
    {
        calcPoint();
        calcSquare();
        point[0] = up1;
        point[1] = up2;
        point[2] = down1;
        point[3] = down2;
    }
}

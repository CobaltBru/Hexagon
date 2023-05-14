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
    void calcPoint(Vector3 start, Vector3 end, double currentTime)
    {
        double ans;

    }


    void Awake()
    {
        point= new Vector3[4] {up1,up2,down2,down1};
        len = polygonGenerator.getLen();
    }
    void Update()
    {
        


    }

    void callNote(int num, double boxSize)
    {
        currentEdge= num;
        this.boxSize = boxSize;
    }
    Vector3[] getSquare()
    {
        Vector3[] points = new Vector3[4];
        int vertex = polygonGenerator.getCurrentPoly();
        float firstDegree = polygonGenerator.getfirstDegree();
        if(vertex == 4)
        {

        }
        else if(vertex == 5)
        {

        }
        else if(vertex == 6)
        {

        }
        return points;
    }
}

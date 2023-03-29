using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int GameSpeed;
    public float radius;
    public PolygonGenerator poly;
    public int polygon;
    int polyold;
    public float deg;
    Vector3[] BackGroundNode;
    
    void Awake()
    {
        polyold = 0;
        
    }

    
    void Update()
    {
        if (polyold != polygon)
        {
            polyold = polygon;
            if(polyold == 6) {
                BackGroundNode = poly.Hexagon(radius);
                poly.createProceduralMesh(BackGroundNode);
            }
            else if(polyold ==5) {
                BackGroundNode = poly.Pentagon(radius);
                poly.createProceduralMesh(BackGroundNode);
            }
            else if (polyold == 4) {
                BackGroundNode = poly.Square(radius);
                poly.createProceduralMesh(BackGroundNode);
            }
        }
    }

    
}

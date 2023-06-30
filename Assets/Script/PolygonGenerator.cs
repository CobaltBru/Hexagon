using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;


public class PolygonGenerator : MonoBehaviour
{
    public GameManager gameManager;

    
    public BackgroundGenerator BackGroundpoly;
    public MiddleGenerator MiddleOutPoly;
    public MiddleGenerator MiddleInPoly;
    public int polygon;
    float radius;
    float radius2;
    float radius3;
    int speed;
    int polyold;
    int tmppoly;
    float firstDegree;
    bool firstin;
    public Vector3[] BackGroundNode;
    public Vector3[] MiddleOutNode;
    public Vector3[] MiddleInNode;

    void Start()
    {
        radius = 6.0f;
        radius2 = 0.5f;
        radius3 = 0.435f;
        speed = gameManager.GameSpeed;
        polyold = polygon;
        tmppoly = polygon;
        firstin = false;
        firstDegree = 360 / polygon;
        drawBackground();
    }

    void Update()
    {
        speed = gameManager.GameSpeed*12;
        if (polyold != polygon)
        {
            if (polyold > polygon)
            {
                if (firstin == false)
                {
                    firstin = true;
                    firstDegree = 360 / polyold;
                    tmppoly = polyold;
                }
                else
                {
                    firstDegree -= 1 * Time.deltaTime * speed / 3.0f;
                    if (firstDegree <= 0)
                    {
                        tmppoly = polygon;
                        polyold = polygon;
                        firstin = false;
                        firstDegree = 360 / polygon;
                    }
                }
            }
            else
            {
                if (firstin == false)
                {
                    firstin = true;
                    firstDegree = 0;
                    tmppoly = polygon;
                }
                else
                {
                    firstDegree += 1 * Time.deltaTime * speed / 3.0f;
                    if (firstDegree >= (360 / polygon))
                    {
                        polyold = polygon;
                        firstin = false;
                        firstDegree = 360 / polygon;
                    }
                }
            }
            drawBackground();
            
        }
    }
    void drawBackground()
    {
        //¹è°æ
        BackGroundNode = BackGroundpoly.PolygonFunc(radius, tmppoly, firstDegree);
        BackGroundpoly.createProceduralMesh(BackGroundNode);

        //Áß¾Ó ¹Ù±ù
        MiddleOutNode = MiddleOutPoly.PolygonFunc(radius2, tmppoly, firstDegree);
        MiddleOutPoly.createProceduralMesh(MiddleOutNode);

        //Áß¾Ó Áß¾Ó
        MiddleInNode = MiddleInPoly.PolygonFunc(radius3, tmppoly, firstDegree);
        MiddleInPoly.createProceduralMesh(MiddleInNode);
    }
    float calcChangeDegree(int one, int two)
    {
        if (one > two)
        {
            return -1 * Time.deltaTime * speed / 50.0f;
        }
        else
        {
            return Time.deltaTime * speed / 50.0f;
        }
    }

    public void setPoly(int poly)
    {
        polygon = poly;
    }


    public Vector3[] getOutPoly() { return BackGroundNode; }
    public Vector3[] getInPoly() { return MiddleOutNode; }
    public int getCurrentPoly() { return polyold; }
    public float getfirstDegree() { return firstDegree; }
    public float getOutRadius() { return radius; }
    public float getInRadius() { return radius2; }
}

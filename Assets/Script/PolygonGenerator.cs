using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;


public class PolygonGenerator : MonoBehaviour
{
    public GameManager gameManager;
    

    public BackgroundGenerator BackGroundpoly;
    public MiddleOutGenerator MiddleOutPoly;
    public MiddleInGenerator MiddleInPoly;
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

    void Awake()
    {
        radius = 6.0f;
        radius2 = 0.5f;
        radius3 = 0.435f;
        speed = gameManager.GameSpeed;
        polyold = 6;
        tmppoly = 6;
        firstin = false;
        //¹è°æ
        BackGroundNode = BackGroundpoly.PolygonFunc(radius, tmppoly, 60.0f);
        BackGroundpoly.createProceduralMesh(BackGroundNode);

        //Áß¾Ó ¹Ù±ù
        MiddleOutNode = MiddleOutPoly.PolygonFunc(radius2, tmppoly, 60.0f);
        MiddleOutPoly.createProceduralMesh(MiddleOutNode);

        //Áß¾Ó Áß¾Ó
        MiddleInNode = MiddleInPoly.PolygonFunc(radius3, tmppoly, 60.0f);
        MiddleInPoly.createProceduralMesh(MiddleInNode);
    }

    void Update()
    {
        speed = gameManager.GameSpeed;
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


}

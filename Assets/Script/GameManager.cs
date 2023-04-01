using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int GameSpeed;
    public float radius;
    public float radius2;
    public float radius3;
    public PolygonGenerator BackGroundpoly;
    public MiddleOutGenerator MiddleOutPoly;
    public MiddleInGenerator MiddleInPoly;
    public int polygon;
    int polyold;
    int tmppoly;
    float firstDegree;
    bool firstin;
    Vector3[] BackGroundNode;
    Vector3[] MiddleOutNode;
    Vector3[] MiddleInNode;
    
    void Awake()
    {
        polyold = 6;
        tmppoly = 6;
        firstin= false;
        //���
        BackGroundNode = BackGroundpoly.PolygonFunc(radius, tmppoly, 60);
        BackGroundpoly.createProceduralMesh(BackGroundNode);

        //�߾� �ٱ�
        MiddleOutNode = MiddleOutPoly.PolygonFunc(radius2, tmppoly, 60);
        MiddleOutPoly.createProceduralMesh(MiddleOutNode);

        //�߾� �߾�
        MiddleInNode = MiddleInPoly.PolygonFunc(radius3, tmppoly, 60);
        MiddleInPoly.createProceduralMesh(MiddleInNode);
    }

    
    void Update()
    {
        if (polyold != polygon)
        {
            if(polyold>polygon)
            {
                if(firstin==false)
                {
                    firstin = true;
                    firstDegree = 360 / polyold;
                    tmppoly = polyold;
                }
                else
                {
                    firstDegree -= 1 * Time.deltaTime * GameSpeed / 3.0f;
                    if(firstDegree<=0)
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
                if(firstin==false)
                {
                    firstin = true;
                    firstDegree = 0;
                    tmppoly = polygon;
                }
                else
                {
                    firstDegree += 1 * Time.deltaTime * GameSpeed / 3.0f;
                    if(firstDegree>=(360/polygon))
                    {
                        polyold = polygon;
                        firstin = false;
                        firstDegree = 360 / polygon;
                    }
                }
            }
            //���
            BackGroundNode = BackGroundpoly.PolygonFunctmp(radius, tmppoly, firstDegree);
            BackGroundpoly.createProceduralMesh(BackGroundNode);

            //�߾� �ٱ�
            MiddleOutNode = MiddleOutPoly.PolygonFunc(radius2, tmppoly, firstDegree);
            MiddleOutPoly.createProceduralMesh(MiddleOutNode);

            //�߾� �߾�
            MiddleInNode = MiddleInPoly.PolygonFunc(radius3, tmppoly, firstDegree);
            MiddleInPoly.createProceduralMesh(MiddleInNode);
        }
    }
    float calcChangeDegree(int one, int two)
    {
        if(one>two) 
        {
            return -1 * Time.deltaTime * GameSpeed/50.0f;
        }
        else
        {
            return Time.deltaTime * GameSpeed/50.0f;
        }
    }
    
}

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
    Vector3 up1;
    Vector3 up2;
    Vector3 down1;
    Vector3 down2;
    int currentEdge;
    double time;
    
    double calcPoint(Vector3 start, Vector3 end, double currentTime)
    {
        double ans;

        return ans;
    }


    void Awake()
    {
        point= new Vector3[4] {up1,up2,down2,down1};
    }
    void Update()
    {
        


    }

    void callNote(int num, double time)
    {
        currentEdge= num;
        this.time = time;
    }
}

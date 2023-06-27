using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Mesh mesh;
    public PolygonGenerator polygonGenerator;
    public GameManager gameManager;
    int speed;
    Vector3[] outPoly;
    Vector3[] inPoly;
    Vector3[] noteBlock;
    int[] noteBlockIdx;

    Vector3 up1;
    Vector3 up2;
    Vector3 down1;
    Vector3 down2;

    int currentEdge;
    float timeLen; // 노트의 길이
    int vertex;
    float time;

    public Note(int num, float timeLen)
    {
        currentEdge = num;
        this.timeLen = timeLen;
    }

    public void callNote(int num, float timeLen)
    {
        currentEdge = num;
        this.timeLen = timeLen;
        gameObject.SetActive(true);
    }

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        outPoly = new Vector3[7];
        inPoly = new Vector3[7];
        noteBlock = new Vector3[4];
        noteBlockIdx = new int[] { 0,3,2,0,2,1 };
        vertex = polygonGenerator.getCurrentPoly();
        vertex = 6;
        
    }
    void Update()
    {
        init();
        time += Time.deltaTime * speed;
        if(time<2000f)
        {
            callDown(time / 2000);
        }
        
        if(time>timeLen)
        {
            callUp((time - timeLen) / 2000);
        }
        createProceduralMesh();
        Debug.Log(time + " " + noteBlock[0] + " " + noteBlock[1] + " " + noteBlock[2] + " " + noteBlock[3]);
    }

    void callDown(float p)
    {
        noteBlock[2] = Vector3.Lerp(up1, down1, p);
        noteBlock[3] = Vector3.Lerp(up2, down2, p);
    }
    void callUp(float p)
    {
        noteBlock[0] = Vector3.Lerp(up1, down1, p);
        noteBlock[1] = Vector3.Lerp(up2, down2, p);
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
        speed = gameManager.GameSpeed;
        calcPoint();
        calcSquare();
    }

    public void createProceduralMesh()
    {
        mesh.Clear();

        mesh.vertices = noteBlock;
        mesh.triangles = noteBlockIdx;
        mesh.RecalculateNormals();
    }
}

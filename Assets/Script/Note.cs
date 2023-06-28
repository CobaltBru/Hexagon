using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Mesh mesh; //메쉬
    public PolygonGenerator polygonGenerator; // 첫각도와 배경이 몇각형인지 받아온다
    public GameManager gameManager; //게임 속도를 받아온다.
    int speed; //게임속도 저장
    Vector3[] outPoly; //바깥 다각형의 좌표 저장
    Vector3[] inPoly; //안쪽 다각형의 좌표 저장
    Vector3[] noteBlock; //사각형 노트블럭의 4개의 좌표 저장
    int[] noteBlockIdx; //메쉬에 쓸 노트블럭 렌더링 인덱스

    Vector3 up1; //노트블럭 사각형의 오른쪽 위
    Vector3 up2; //왼쪽 위
    Vector3 down1; //오른쪽 아래
    Vector3 down2; //왼쪽 아래

    int currentEdge; //어느위치에서 내려올 것인지
    float timeLen; // 노트의 길이
    int vertex; //호출한 시점에서 배경 다각형의 꼭짓점 수
    int changed_vertex; //배경 다각형의 꼭짓점 수가 변하는지 체크
    float time; //시간

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

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        outPoly = new Vector3[7];
        inPoly = new Vector3[7];
        noteBlock = new Vector3[4];
        noteBlockIdx = new int[] { 0,3,2,0,2,1 };
        vertex = polygonGenerator.getCurrentPoly();
        changed_vertex = polygonGenerator.getCurrentPoly();
    }
    void Update()
    {
        init();
        time += Time.deltaTime * speed;
        if(time<2000f)
        {
            callDown(time / 2000);
            callUp(0.0f);
        }
        
        if(time>timeLen)
        {
            callUp((time - timeLen) / 2000);
            callDown(time / 2000);
        }
        createProceduralMesh();
        if((time - timeLen) / 2000>=1.0f)
        {
            gameObject.SetActive(false);
        }
        Debug.Log(time + " " + noteBlock[0] + " " + noteBlock[1] + " " + noteBlock[2] + " " + noteBlock[3]);
    }

    void callDown(float p)
    {
        noteBlock[1] = Vector3.Lerp(up1, down1, p);
        noteBlock[2] = Vector3.Lerp(up2, down2, p);
    }
    void callUp(float p)
    {
        noteBlock[0] = Vector3.Lerp(up1, down1, p);
        noteBlock[3] = Vector3.Lerp(up2, down2, p);
    }


    
    
    void calcPoint()
    {
        vertex = polygonGenerator.getCurrentPoly();
        float firstDegree = polygonGenerator.getfirstDegree();
        float radius1 = polygonGenerator.getOutRadius();
        float radius2 = polygonGenerator.getInRadius();
        float deg = (360 - firstDegree) / (vertex - 1);

        for (int i = 0; i <= 1; i++)
        {
            var rad = Mathf.Deg2Rad * (firstDegree * i);
            var x = radius1 * Mathf.Sin(rad);
            var y = radius1 * Mathf.Cos(rad);
            outPoly[i] = new Vector3(x, y);
            x = radius2 * Mathf.Sin(rad);
            y = radius2 * Mathf.Cos(rad);
            inPoly[i] = new Vector3(x, y);
        }
        for (int i = 2; i < vertex; i++)
        {
            var rad = Mathf.Deg2Rad * ((deg * (i - 1)) + firstDegree);
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
        changed_vertex = polygonGenerator.getCurrentPoly();
        if (vertex > changed_vertex)
        {
            if (currentEdge == 0)
            {
                gameObject.SetActive(false);
                return;
            }
            else
            {
                currentEdge--;
            }

        }
        else if(vertex < changed_vertex)
        {
            currentEdge++;
        }
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

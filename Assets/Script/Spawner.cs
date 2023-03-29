using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject square;
    public GameObject middle;
    public GameManager gameManager;
    float move;
    Vector2 dir;
    void Awake()
    {
        dir = middle.transform.position - square.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        square.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
    void Update()
    {
        var x = square.transform.position.x + dir.x * Time.deltaTime * gameManager.GameSpeed / 500;
        var y = square.transform.position.y + dir.y * Time.deltaTime * gameManager.GameSpeed / 500;
        square.transform.position = new Vector2(x, y);
        

    }
}

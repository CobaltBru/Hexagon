using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    Rigidbody2D rigid;
    float deg;

    public float radius;
    public GameManager gameManager;

    void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        deg = 0;
    }
    void Update()
    {
        deg += Time.deltaTime * gameManager.GameSpeed * Input.GetAxisRaw("Horizontal");
        if (deg < 0) deg = 360;
        else if (deg > 360) deg = 0;
        else
        {
            var rad = Mathf.Deg2Rad * (deg);
            var x = radius * Mathf.Sin(rad);
            var y = radius * Mathf.Cos(rad);
            rigid.transform.position = new Vector3(x, y);
            Debug.Log(x+ " " + y);
            rigid.transform.rotation = Quaternion.Euler(0, 0, deg * -1);
        }
    }
}

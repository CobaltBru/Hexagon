using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    GameManager gameManager;
    Vector3[] BackGroundNode;
    Vector3[] MiddleOutNode;
    void Awake()
    {
        BackGroundNode = gameManager.BackGroundNode;
        MiddleOutNode = gameManager.MiddleOutNode;
    }
    void Update()
    {
        
        

    }
}

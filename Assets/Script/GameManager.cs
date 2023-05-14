using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int GameSpeed;
    public PolygonGenerator polygonGenerator;
    
    
    void Start()
    {
        polygonGenerator.setPoly(6);
        

    }

    
    void Update()
    {
        
    }
    
}

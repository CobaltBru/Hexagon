using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int GameSpeed;
    public Note[] note;
    public PolygonGenerator polygonGenerator;
    
    
    void Start()
    {
        polygonGenerator.setPoly(6);
        note[0].callNote(0, 300.0f);
        note[1].callNote(2, 600.0f);
        note[2].callNote(4, 900.0f);

    }

    
    void Update()
    {
        
    }
    
}

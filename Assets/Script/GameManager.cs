using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int GameSpeed;
    public Note note;
    public PolygonGenerator polygonGenerator;
    
    
    void Start()
    {
        polygonGenerator.setPoly(6);
        note.callNote(2, 3000.0f);

    }

    
    void Update()
    {
        
    }
    
}

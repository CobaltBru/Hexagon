using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject notePrefab;
    float time;
    void Awake()
    {
        

    }

    void Update()
    {
        time = Time.deltaTime;
        pattern(time);
    }
    void pattern(float time)
    {
        if(time< 2.0f)
        {

        }
        else if(time<2.5f)
        {
            Debug.Log("fdas");
            createNote(2.0f, 1.0f, 1);
        }
    }
    void createNote(float timing, float len, int pos)
    {
        GameObject note = Instantiate(notePrefab);
        note.GetComponent<Note>().callNote(pos, len);
        Destroy(note, 5.0f);
    }
}

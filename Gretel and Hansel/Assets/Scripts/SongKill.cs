using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongKill : MonoBehaviour
{
    public GameObject[] song;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        song = GameObject.FindGameObjectsWithTag("song");
        if (song.Length > 1)
        {
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Songplayer : MonoBehaviour
{

    public AudioSource aud;


    private void Awake()
    {
        Cursor.visible = false;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        /*if (!aud.isPlaying)
        {
            aud.Play();
        }*/
    }
}

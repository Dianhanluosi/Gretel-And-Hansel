using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuirOrReload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("B1") || Input.GetButton("B2") || Input.GetButton("B3"))
        {
            Application.Quit();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    bool load = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!load && Input.GetButton("A1") || !load && Input.GetButton("A2") || !load && Input.GetButton("A3"))
        {
            load = true;
            SceneManager.LoadScene(1);
        }
    }
}

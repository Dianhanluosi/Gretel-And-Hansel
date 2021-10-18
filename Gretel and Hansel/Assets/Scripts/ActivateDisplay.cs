using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDisplay : MonoBehaviour
{


    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
        }
        else if (Display.displays.Length > 2)
        {
            Display.displays[1].Activate();
            Display.displays[2].Activate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

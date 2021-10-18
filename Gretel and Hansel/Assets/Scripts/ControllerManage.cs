using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManage : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("A1"))
        {
            print("1");
        }

        if (Input.GetButton("A2"))
        {
            print("2");
        }

        if (Input.GetButton("A3"))
        {
            print("3");
        }

    }
}

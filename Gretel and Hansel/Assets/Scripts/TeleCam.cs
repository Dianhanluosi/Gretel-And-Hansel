using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleCam : MonoBehaviour
{

    public float thisX;

    public float thisY;

    public bool CamOn = false;
    public GameObject Cam;

    public int thisNum;

    // Start is called before the first frame update
    void Start()
    {
        thisX = gameObject.GetComponent<Transform>().position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (CamOn)
        {
            Cam.SetActive(true);
        }
        else
        {
            Cam.SetActive(false);
        }
    }
}

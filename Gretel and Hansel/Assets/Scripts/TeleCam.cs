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

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        thisX = gameObject.GetComponent<Transform>().position.x;
    }

    // Update is called once per frame
    void Update()
    {


        anim.SetBool("Play", CamOn);


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

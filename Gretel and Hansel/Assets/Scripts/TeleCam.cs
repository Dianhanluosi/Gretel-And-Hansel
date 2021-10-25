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


    public GameObject A;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        thisX = gameObject.GetComponent<Transform>().position.x - 0.5f ;
    }

    // Update is called once per frame
    void Update()
    {


        anim.SetBool("Play", CamOn);


        if (CamOn)
        {
            Cam.SetActive(true);
            A.SetActive(false);
        }
        else
        {
            Cam.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Witch"))
        {
            A.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Witch"))
        {
            A.SetActive(false);
        }
    }

}

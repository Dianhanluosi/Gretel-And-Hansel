using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampOn : MonoBehaviour
{

    Animator anim;

    public OpenUiA A;

    public bool canOn = false;

    public bool on = false;


    public GHControl Gretel;
    public GHControl Hansel;
    public WitchControl Witch;

    public GameObject stairs1;
    public GameObject stairs2;


    public Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetBool("On", on);


        if (A.AUIG.activeSelf || A.AUIH.activeSelf || A.AUIW.activeSelf)
        {
            canOn = true;
        }
        else
        {
            canOn = false;
        }

        if (canOn)
        {
            if (!on && A.AUIG.activeSelf && Gretel.AButton)
            {
                on = true;
            }
            if (!on && A.AUIH.activeSelf && Hansel.AButton)
            {
                on = true;
            }
            if (!on && A.AUIW.activeSelf && Witch.AButton)
            {
                on = true;
            }

        }

            
        if (on)
        {
            coll.enabled = false;
            stairs1.SetActive(true);
            stairs2.SetActive(true);

        }
        else
        {
            stairs1.SetActive(false);
            stairs2.SetActive(false);

        }



    }

    
}

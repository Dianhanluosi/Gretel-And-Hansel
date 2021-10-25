using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewageOpen : MonoBehaviour
{

    public GHControl Gretel;
    public GHControl Hansel;

    public GameObject textG;
    public GameObject textH;

    public Collider2D buttonG;
    public Collider2D buttonH;


    public OpenUiA A;
    public OpenUiA A2;


    public bool canUnlock = false;
    public bool canUse = false;

    Animator anim;

    public bool GN = false;
    public bool HN = false;

    public GameObject bolt;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gretel.haveWrench || Hansel.haveWrench)
        {
            textG.SetActive(false);
            textH.SetActive(false);
        }

        


        if (Gretel.haveWrench || canUse)
        {
            buttonG.enabled = true;
        }
        else
        {
            buttonG.enabled = false;
        }

        if (Hansel.haveWrench || canUse)
        {
            buttonH.enabled = true;
        }
        else
        {
            buttonH.enabled = false;
        }




        if (!canUnlock)
        {
            if (A.AUIG.activeSelf && Gretel.AButton|| A2.AUIH.activeSelf && Hansel.AButton)
            {
                canUnlock = true;
                bolt.SetActive(true);
            }
        }
        anim.SetBool("can", canUnlock);

       



        if (canUse && GN && Gretel.AButton)
        {
            Gretel.escaped = true;
        }

        if (canUse && HN && Hansel.AButton)
        {
            Hansel.escaped = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gretel"))
        {
            GN = true;
        }
        if (collision.gameObject.CompareTag("Hansel"))
        {
            HN = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gretel"))
        {
            GN = false;
        }
        if (collision.gameObject.CompareTag("Hansel"))
        {
            HN = false;
        }
    }
}

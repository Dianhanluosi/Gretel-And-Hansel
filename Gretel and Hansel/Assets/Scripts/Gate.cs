using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    public GHControl Gretel;
    public GHControl Hansel;

    public GameObject textG;
    public GameObject textH;
    public Collider2D buttons;

    public bool canUse;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gretel.haveKey || Hansel.haveKey)
        {
            textG.SetActive(false);
            textH.SetActive(false);
        }

        if (Gretel.haveKey || Hansel.haveKey)
        {
            buttons.enabled = true;
        }
        else
        {
            buttons.enabled = false;
        }

        if (canUse && Hansel.haveKey && Gretel.AButton)
        {
            Gretel.escaped = true;
        }

        if (canUse && Hansel.haveKey && Hansel.AButton)
        {
            Hansel.escaped = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gretel") || collision.gameObject.CompareTag("Hansel"))
        {
            canUse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gretel") || collision.gameObject.CompareTag("Hansel"))
        {
            canUse = false;
        }
    }
}

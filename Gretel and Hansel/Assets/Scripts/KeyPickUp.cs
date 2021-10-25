using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{

    public OpenUiA A;

    public bool canPickUp = false;
    public bool pickedUp = false;

    public GHControl Gretel;
    public GHControl Hansel;

    public Collider2D coll;

    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (A.AUIG.activeSelf || A.AUIH.activeSelf )
        {
                canPickUp = true;
        }
        else
        {
            canPickUp = false;
        }



        if (canPickUp)
        {
            if (!pickedUp && A.AUIG.activeSelf && Gretel.AButton)
            {
                pickedUp = true;
                Gretel.haveKey = true;
            }
            if (!pickedUp && A.AUIH.activeSelf && Hansel.AButton)
            {
                pickedUp = true;
                Hansel.haveKey = true;
            }
            

        }


        if (pickedUp)
        {
            Destroy(key);
            coll.enabled = false;
        }
       




    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchPickUp : MonoBehaviour
{
    public OpenUiA A;


    public GHControl Gretel;
    public GHControl Hansel;

    public bool canPickUp = false;
    public bool pickedUp = false;



    public GameObject Wrench;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Gretel.haveCrowBar)
        {
            A.AUIG.SetActive(false);
        }
        else
        {

        }

        if (Hansel.haveCrowBar)
        {
            A.AUIH.SetActive(false);
        }
        else
        {

        }

        if (A.AUIG.activeSelf || A.AUIH.activeSelf)
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
                Gretel.haveWrench = true;
            }
            if (!pickedUp && A.AUIH.activeSelf && Hansel.AButton)
            {
                pickedUp = true;
                Hansel.haveWrench = true;
            }
        }




        if (pickedUp)
        {
            Destroy(Wrench) ;

        }





    }
}

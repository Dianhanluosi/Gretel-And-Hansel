using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour
{
    public OpenUiA A;


    public GHControl Gretel;
    public GHControl Hansel;

    public bool canPickUp = false;
    public bool pickedUp = false;



    public GameObject Crowbarr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Gretel.haveWrench)
        {
            A.AUIG.SetActive(false);
        }
        else
        {

        }

        if (Hansel.haveWrench)
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
                Gretel.haveCrowBar = true;
            }
            if (!pickedUp && A.AUIH.activeSelf && Hansel.AButton)
            {
                pickedUp = true;
                Hansel.haveCrowBar = true;
            }
        }




        if (pickedUp)
        {
            Destroy(Crowbarr);

        }





    }
}

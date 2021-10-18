using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomBlackOutManager : MonoBehaviour
{

    public GameObject Gretel;
    public GameObject Hansel;
    public GameObject Witch;


    public DoorOpen LeftDoor;
    public DoorOpen RightDoor;

    public bool LeftOpen;
    public bool RightOpen;


    public bool GretelSee;
    public bool HanselSee;
    public bool WitchSee;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        DoorIndicator();


        Visibility();
        

        


    }


    void Visibility()
    {
        if (GretelSee)
        {
            Gretel.SetActive(false);
        }
        else
        {
            Gretel.SetActive(true);
        }

        if (HanselSee)
        {
            Hansel.SetActive(false);
        }
        else
        {
            Hansel.SetActive(true);
        }

        if (WitchSee)
        {
            Witch.SetActive(false);
        }
        else
        {
            Witch.SetActive(true);
        }


        if (!GretelSee)
        {

        }

        if (!HanselSee)
        {

        }

        if (!WitchSee)
        {

        }


    }

    void DoorIndicator()
    {
        if (LeftDoor != null)
        {
            if (!LeftDoor.GetComponent<DoorOpen>().doorClosed)
            {
                LeftOpen = true;
            }
            else
            {
                LeftOpen = false;
            }
        }

        if (RightDoor != null)
        {
            if (!RightDoor.GetComponent<DoorOpen>().doorClosed)
            {
                RightOpen = true;
            }
            else
            {
                RightOpen = false;
            }
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gretel"))
        {
            GretelSee = true;
        }
        if (collision.gameObject.CompareTag("Hansel"))
        {
            HanselSee = true;
        }
        if (collision.gameObject.CompareTag("Witch"))
        {
            WitchSee = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gretel"))
        {
            GretelSee = false;
        }
        if (collision.gameObject.CompareTag("Hansel"))
        {
            HanselSee = false;
        }
        if (collision.gameObject.CompareTag("Witch"))
        {
            WitchSee = false;
        }
    }
}

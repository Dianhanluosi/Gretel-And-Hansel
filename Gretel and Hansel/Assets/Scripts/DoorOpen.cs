using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    public GameObject door;
    public Vector2 doorPos;

    public bool canBeUsedByGretel = false;
    public bool canBeUsedByHansel = false;
    public bool canBeUsedByWitch = false;

    public bool doorClosed = true;

    private void Awake()
    {
        doorPos = door.GetComponent<Transform>().position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (canBeUsedByGretel && Input.GetButtonDown("A1"))
        {
            doorClosed = !doorClosed;
        }




        if (doorClosed)
        {
            door.GetComponent<Transform>().position = doorPos;
        }
        if (!doorClosed)
        {
            door.GetComponent<Transform>().position = doorPos + new Vector2(0, 1f);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gretel"))
        {
            canBeUsedByGretel = true;
        }
        if (collision.gameObject.CompareTag("Hansel"))
        {
            canBeUsedByHansel = true;
        }
        if (collision.gameObject.CompareTag("Witch"))
        {
            canBeUsedByWitch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gretel") || collision.gameObject.CompareTag("Hansel") || collision.gameObject.CompareTag("Witch"))
        {
            canBeUsedByGretel = false;
        }
        if (collision.gameObject.CompareTag("Gretel") || collision.gameObject.CompareTag("Hansel") || collision.gameObject.CompareTag("Witch"))
        {
            canBeUsedByHansel = false;
        }
        if (collision.gameObject.CompareTag("Gretel") || collision.gameObject.CompareTag("Hansel") || collision.gameObject.CompareTag("Witch"))
        {
            canBeUsedByWitch = false;
        }
    }
}

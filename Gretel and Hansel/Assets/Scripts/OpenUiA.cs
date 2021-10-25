using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUiA : MonoBehaviour
{

    public GameObject AUIG;
    public GameObject AUIH;
    public GameObject AUIW;

    public bool includeWitch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gretel"))
        {
            AUIG.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Hansel"))
        {
            AUIH.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Witch"))
        {
            if (includeWitch)
            {
                AUIW.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gretel"))
        {
            AUIG.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Hansel"))
        {
            AUIH.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Witch"))
        {
            AUIW.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateLadder : MonoBehaviour
{

    public GameObject stairs;


    // Start is called before the first frame update
    void Start()
    {
        stairs.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gretel") || collision.gameObject.CompareTag("Hansel") || collision.gameObject.CompareTag("Witch"))
        stairs.SetActive(true);
    }

}

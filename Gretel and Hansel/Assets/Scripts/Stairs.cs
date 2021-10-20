using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{

   

    public float offSet = 0.3f;

    public bool facingLeft;

    public float thisX;

    public float thatX;

    public float thisY;

    public float thatY;

    private void Awake()
    {
        if (facingLeft)
        {
            offSet = -offSet;
        }
        else
        {

        }

        thisX = gameObject.GetComponent<Transform>().position.x + offSet;

    }


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

    }
}

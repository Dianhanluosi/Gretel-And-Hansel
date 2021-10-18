using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{


    public Vector2 nextDoorPos;

    public Vector2 offSet;

    //if door is on the left of the room
    public bool Left = false;


    private void Awake()
    {

        offSet = new Vector2(0.3f, 0);

        
        if (Left)
        {
            offSet = -offSet;
        }
        else
        {

        }
        

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

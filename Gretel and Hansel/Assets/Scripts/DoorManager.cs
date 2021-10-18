using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    public Doors[] doors;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //assign each door the position info of the next door or previous
        for (int i = 0; i < doors.Length; i++)
        {
            if (!doors[i].Left && doors[i+1] != null)
            {
                doors[i].nextDoorPos = doors[i + 1].transform.position;
            }
            if (doors[i].Left && doors[i-1] != null)
            {
                doors[i].nextDoorPos = doors[i - 1].transform.position;

            }
        }

    }
}

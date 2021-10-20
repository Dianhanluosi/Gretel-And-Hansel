using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    public Doors[] doors1;

    public Doors[] doors2;

    public Doors[] doors3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //assign each door the position info of the next door or previous
        for (int i = 0; i < doors1.Length; i++)
        {
            if (!doors1[i].Left && doors1[i+1] != null)
            {
                doors1[i].nextDoorPos = doors1[i + 1].transform.position;
            }
            if (doors1[i].Left && doors1[i-1] != null)
            {
                doors1[i].nextDoorPos = doors1[i - 1].transform.position;

            }
        }


        for (int i = 0; i < doors2.Length; i++)
        {
            if (!doors2[i].Left && doors2[i + 1] != null)
            {
                doors2[i].nextDoorPos = doors2[i + 1].transform.position;
            }
            if (doors2[i].Left && doors2[i - 1] != null)
            {
                doors2[i].nextDoorPos = doors2[i - 1].transform.position;

            }
        }


        for (int i = 0; i < doors3.Length; i++)
        {
            if (!doors3[i].Left && doors3[i + 1] != null)
            {
                doors3[i].nextDoorPos = doors3[i + 1].transform.position;
            }
            if (doors3[i].Left && doors3[i - 1] != null)
            {
                doors3[i].nextDoorPos = doors3[i - 1].transform.position;

            }
        }

       

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsManager : MonoBehaviour
{

    public Stairs[] stairsDown;
    public Stairs[] stairsUp;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < stairsDown.Length; i++)
        {
            stairsDown[i].thatX = stairsUp[i].thisX;
            stairsDown[i].thatY = stairsUp[i].thisY;
            stairsUp[i].thatX = stairsDown[i].thisX;
            stairsUp[i].thatY = stairsDown[i].thisY;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

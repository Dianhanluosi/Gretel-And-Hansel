using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{

    public GHControl Gretel;
    public GHControl Hansel;


    public int survive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gretel.escaped && Hansel.escaped)
        {
            survive = 1;
        }
        if (Gretel.escaped && Hansel.caught)
        {
            survive = 2;
        }
        if (Gretel.caught && Hansel.escaped)
        {
            survive = 3;
        }
    }
}

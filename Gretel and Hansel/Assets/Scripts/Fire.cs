using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public Animator anim;

    public bool burn = false;

    public WitchControl witch;

    public bool canburn;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {




        //burning
        if (!witch.isntCarryingGretel && canburn && witch.AButton)
        {
            burn = true;
            witch.gretelBurned = true;
        }

        if (!witch.isntCarryingHansel && canburn && witch.AButton)
        {
            burn = true;
            witch.hanselBurned = true;
        }

        anim.SetBool("Burned", burn);

    }


}

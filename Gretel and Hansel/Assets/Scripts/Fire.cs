using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public Animator anim;

    public bool burn = false;

    public WitchControl witch;

    public bool canburn;

    public GameObject A;

    public int death = 0;


    public GameObject stairs1;
    public GameObject starits2;


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
            death += 1;
            burn = true;
            witch.gretelBurned = true;
        }

        if (!witch.isntCarryingHansel && canburn && witch.AButton)
        {
            death += 1;
            burn = true;
            witch.hanselBurned = true;
        }


        if (!witch.isntCarrying && canburn)
        {
            A.SetActive(true);
        }
        else
        {
            A.SetActive(false);
        }


        anim.SetBool("Burned", burn);


        if (death  > 0)
        {
            stairs1.SetActive(true);
            starits2.SetActive(true);
        }
        else
        {
            stairs1.SetActive(false);
            starits2.SetActive(false) ;
        }

    }


}

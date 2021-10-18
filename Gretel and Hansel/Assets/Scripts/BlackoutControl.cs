using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutControl : MonoBehaviour
{


    public bool black = false;

    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("black", black);
    }
}

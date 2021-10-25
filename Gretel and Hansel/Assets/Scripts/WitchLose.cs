using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchLose : MonoBehaviour
{
    public EndingManager EM;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("end", EM.survive);

    }
}

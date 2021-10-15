using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GHControl : MonoBehaviour
{

    //strings to reference inputs
    public string playerNum;

    public string H;

    public string V;

    public string A;

    public string B;


    //referencing rigidbody
    Rigidbody2D rb;

    //speed variables
    public float xSpeed;

    private void Awake()
    {
        H = "Horizontal" + playerNum ;
        V = "Vertical" + playerNum;
        A = "A" + playerNum;
        B = "B" + playerNum;

        rb = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(H) != 0)
        {
            rb.AddForce(new Vector2(Input.GetAxis(H) * xSpeed * Time.deltaTime, 0));
        }

    }
}

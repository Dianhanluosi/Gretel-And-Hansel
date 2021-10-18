using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchControl : MonoBehaviour
{ //strings to reference inputs
    public string playerNum;

    public string H;
    public bool Horizontal = false;

    public string V;
    public bool Vertical = false;

    public string A;
    public bool AButton = false;

    public string B;
    public bool BButton = false;


    //referencing rigidbody
    Rigidbody2D rb;


    //speed variables
    float xSpeed;
    public float speedValue = 250f;
    public bool isWalking = false;
    public float speedMax = 1f;
    public float speedMin = -1f;


    //refernece animator
    Animator anim;

    //determine which direction the player is facing
    public bool facingLeft = true;


    //bools to determine if can interact with an object

    private void Awake()
    {
        H = "Horizontal" + playerNum;
        V = "Vertical" + playerNum;
        A = "A" + playerNum;
        B = "B" + playerNum;

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Flip();

        Movement();

        animControl();

    }



    void Flip()
    {
        //flip to left
        if (xSpeed < 0 && transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1, 1);
            //transform.localScale = left;
            facingLeft = true;
        }
        //flip to right
        else if (xSpeed > 0 && transform.localScale.x < 0)
        {
            transform.localScale *= new Vector2(-1, 1);
            //transform.localScale = right;
            facingLeft = false;
        }
    }


    void Movement()
    {

        if (Input.GetAxis(H) > 0)
        {
            xSpeed = speedValue;
        }
        else if (Input.GetAxis(H) < 0)
        {
            xSpeed = -speedValue;
        }
        else
        {
            xSpeed = 0;
        }



        rb.AddForce(new Vector2(xSpeed * Time.deltaTime, 0));


        //limit speed
        if (rb.velocity.x >= speedMax)
        {
            rb.velocity = new Vector2(speedMax, 0);
        }
        if (rb.velocity.x <= speedMin)
        {
            rb.velocity = new Vector2(speedMin, 0);
        }

    }

    void animControl()
    {
        anim.SetBool("isWalking", isWalking);

        if (xSpeed != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {

        }
    }
}

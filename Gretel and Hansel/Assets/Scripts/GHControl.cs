using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GHControl : MonoBehaviour
{

    //strings to reference inputs
    public string playerNum;

    public string H;
    public bool Horizontal = false;

    public string V;
    public bool Vertical = false;

    public string A;
    public bool AButton = false;

    public string B;
    public bool BButton = false;


    //bools to indicate whether or not controls are valid
    public bool canMove = true;
    public bool canControl = true;
    public bool canInteract = true;

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


    //variables for teleportation
    public float teleCD = 0.5f;
    public Vector2 NextDoorPos;


    //bools to determine if can interact with an object
    public bool canUseDoor = false;
    public bool doorTeleporting = false;



    //UI control
    //black out
    public BlackoutControl BC;
    public GameObject vCam;


    private void Awake()
    {
        H = "Horizontal" + playerNum ;
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


        InputIndicator();

        Flip();

        if (canMove)
        {
            Movement();
        }

        AnimControl();

        teleCD -= Time.deltaTime;
        Teleporter();
        
    }

    void InputIndicator()
    {


        //A button
        if (Input.GetButtonDown(A))
        {
            AButton = true;
        }
        else
        {
            AButton = false;
        }


        //B button
        if (Input.GetButtonDown(B))
        {
            BButton = true;
        }
        else
        {
            BButton = false;
        }

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

    void AnimControl()
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


    void Teleporter()
    {

        //door teleportation
        if (canUseDoor && AButton)
        {
            teleCD = 1f;
            doorTeleporting = true;
            canMove = false; //cannot move when blacking out
            BC.black = true; //start black out
            vCam.SetActive(false);//turn off vcam
        }
        if (doorTeleporting && teleCD < 0)
        {
            gameObject.transform.position = NextDoorPos;
            BC.black = false;//turn off black out
            vCam.SetActive(true); // turn vcam back on
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Door")) 
        { 
        
            canUseDoor = true;

           

            NextDoorPos = new Vector2(collision.gameObject.GetComponent<Doors>().nextDoorPos.x + collision.gameObject.GetComponent<Doors>().offSet.x, gameObject.transform.position.y);

        }

    }



    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Door"))
        {
            canUseDoor = false;
            doorTeleporting = false;
            canMove = true;
        }
    }

}

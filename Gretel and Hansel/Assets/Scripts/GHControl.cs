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

    public bool tele = false;

    //bools to determine if can interact with an object
    public bool canUseDoor = false;
    public bool doorTeleporting = false;



    //UI control
    //black out
    public BlackoutControl BC;
    public GameObject vCam;


    //being caught
    public bool caught = false;
    public bool canBeCaught = false;
    public GameObject capturescreen;


    public bool dead = false;
    public GameObject deadscreen;


    public bool escaped = false;

    public bool finished = false;


    public Renderer rend;
    public Collider2D coll;


    //buttonUI
    public GameObject AUI;

    //WitchUI

    public GameObject RTUI;



    public bool haveKey;
    public bool haveCrowBar;
    public bool haveWrench;






    private void Awake()
    {
        H = "Horizontal" + playerNum ;
        V = "Vertical" + playerNum;
        A = "A" + playerNum;
        B = "B" + playerNum;

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        rend = GetComponent<Renderer>();

        coll = GetComponent<Collider2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (canControl)
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

        captured();

        Gone();

        if (escaped || caught)
        {
            finished = true;
        }

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
        anim.SetBool("Teleporter", tele);



        //door teleportation
        if (canUseDoor && AButton)
        {
            teleCD = 1f;
            doorTeleporting = true;
            canMove = false; //cannot move when blacking out
            BC.black = true; //start black out
            vCam.SetActive(false);//turn off vcam
            tele = true;
        }
        if (doorTeleporting && teleCD < 0)
        {
            gameObject.transform.position = NextDoorPos;
            BC.black = false;//turn off black out
            vCam.SetActive(true); // turn vcam back on
            tele = false;
        }


    }


    void captured()
    {
        if (caught)
        {
            canMove = false;
            canControl = false;
            rend.enabled = false;
            coll.enabled = false;
            anim.enabled = false;
            rb.isKinematic = true;
            capturescreen.SetActive(true);
            RTUI.SetActive(false);
        }

        
        
        

    }

    void Gone()
    {
        if (escaped)
        {
            canMove = false;
            canControl = false;
            rend.enabled = false;
            coll.enabled = false;
            anim.enabled = false;
            rb.isKinematic = true;
            deadscreen.SetActive(true);
        }

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Door"))
        {

            AUI.SetActive(true);


            canUseDoor = true;

           

            NextDoorPos = new Vector2(collision.gameObject.GetComponent<Doors>().nextDoorPos.x + collision.gameObject.GetComponent<Doors>().offSet.x, gameObject.transform.position.y);

        }

        if (collision.gameObject.CompareTag("Stairs"))
        {

            AUI.SetActive(true);


            canUseDoor = true;



            NextDoorPos = new Vector2(collision.gameObject.GetComponent<Stairs>().thatX, collision.gameObject.GetComponent<Stairs>().thatY);

        }

        if (collision.gameObject.CompareTag("Catcher"))
        {
            RTUI.SetActive(true);
            canBeCaught = true;
        }

    }



    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Door") || collision.gameObject.CompareTag("Stairs"))
        {
            canUseDoor = false;
            doorTeleporting = false;
            canMove = true;
            AUI.SetActive(false) ;

        }

        if (collision.gameObject.CompareTag("Catcher"))
        {
            RTUI.SetActive(false); ;
            canBeCaught = false; ;
        }
    }

}

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

    public string LT;
    public bool LTrig = false;
    public string LB;
    public bool LBButton = false;

    public string RT;
    public bool RTrig = false;
    public string RB;
    public bool RBButton = false;


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


    public bool tele = false;


    //teleportation / venting
    public bool canUseTeleporter = false;
    public TeleManage teleArray;
    public int camnum = 0;
    public int curretnCamNum = 0;
    public int camMax;
    public bool teleCamOn = false;
    public Vector2 TelePos;


    //UI control
    //black out
    public BlackoutControl BC;
    public GameObject vCam;
    public GameObject Cam;


    //attack
    public bool isntCarryingGretel = true;
    public bool isntCarryingHansel = true;
    public bool isntCarrying = true;
    public bool hitting = false;
    public bool attacking = false;
    public bool canCatch = false;

    public bool gretelBurned = false;
    public bool hanselBurned = false;

    public GHControl Gretel;
    public GHControl Hansel;
    public GameObject Ge;
    public GameObject Ha;

    //oven
    public Fire oven;



    public Renderer rend;
    public Collider2D coll;


    public GameObject AUI;


    public bool Win;
    public bool Lose;
    public GameObject LoseScreen;
    public GameObject WinScreen;

    private void Awake()
    {
        H = "Horizontal" + playerNum;
        V = "Vertical" + playerNum;
        A = "A" + playerNum;
        B = "B" + playerNum;
        LT = "LT" + playerNum;
        RT = "RT" + playerNum;
        LB = "LB" + playerNum;
        RB = "RB" + playerNum;

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


        /* if (RBButton)
         {
             camnum += 1;
         }
         if (LBButton)
         {
             camnum -= 1;
         }
         if (camnum > camMax)
         {
             camnum = 0;
         }
         if (camnum < 0)
         {
             camnum = camMax;
         }
         print(camnum);*/



        InputIndicator();

        Flip();

        if (canMove)
        {
            Movement();
        }

        AnimControl();

        teleCD -= Time.deltaTime;
        Teleporter();

        snatching();

        End();

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


        //LT
        if (Input.GetAxis(LT) > 0)
        {
            LTrig = true;
        }
        else
        {
            LTrig = false;
        }


        //RT
        if (Input.GetAxis(RT) > 0)
        {
            RTrig = true;
        }
        else
        {
            RTrig = false;
        }


        //LB
        if (Input.GetButtonDown(LB))
        {
            LBButton = true;
        }
        else
        {
            LBButton = false;
        }


        //RB
        if (Input.GetButtonDown(RB))
        {
            RBButton = true;
        }
        else
        {
            RBButton = false;
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
        anim.SetBool("Teleport", tele);


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
        


        //teleporter teleportation
        if (canUseTeleporter && AButton)
        {
            teleCamOn = true;
            canMove = false;
        }
        if (!canUseTeleporter && !BC.black && !tele && !doorTeleporting)
        {
            teleCamOn = false;
            canMove = true;
        }

        if (camnum > camMax)
        {
            camnum = 0;
        }
        if (camnum < 0)
        {
            camnum = camMax;
        }

        if (teleCamOn)
        {
            if (RBButton)
            {
                camnum += 1;
            }
            if (LBButton)
            {
                camnum -= 1;
            }
            TelePos = new Vector2(teleArray.teleporters[camnum].thisX, teleArray.teleporters[camnum].thisY);

            for (int i = 0; i < teleArray.teleporters.Length; i++)
            {
                if (i == camnum)
                {
                    teleArray.teleporters[i].CamOn = true;
                }
                else
                {
                    teleArray.teleporters[i].CamOn = false;
                }
            }
            Cam.SetActive(false);

        }
        else
        {
            Cam.SetActive(true);
            for (int i = 0; i < teleArray.teleporters.Length; i++)
            {
                teleArray.teleporters[i].CamOn = false;
            }
        }


        
        
        //teleportation
        if (curretnCamNum!=camnum && teleCamOn && AButton)
        {
            gameObject.transform.position = TelePos;
            teleCamOn = false;
            curretnCamNum = camnum;
            canMove = true;
        }
        
        if (teleCamOn && BButton)
        {
            teleCamOn = false;
            canMove = true;
        }




    }

    void snatching()
    {
        anim.SetBool("Meleee", hitting);


        if (!isntCarryingGretel || !isntCarryingHansel)
        {
            isntCarrying = false;
        }
        else
        {
            isntCarrying = true;
        }


        if (isntCarrying && canMove && Input.GetAxis(RT)!= 0)
        {
            hitting = true;
        }
        else
        {
            hitting = false;
        }


        if (Gretel.canBeCaught && attacking)
        {
            Gretel.caught = true;
        }
        if (Gretel.caught)
        {
            isntCarryingGretel = false;
        }

        if (Hansel.canBeCaught && attacking)
        {
            Hansel.caught = true;
        }
        if (Hansel.caught)
        {
            isntCarryingHansel = false;
        }

        if (gretelBurned)
        {
            isntCarryingGretel = true;
        }
        if (hanselBurned)
        {
            isntCarryingHansel = true;
        }

        anim.SetBool("Gretel", !isntCarryingGretel);
        anim.SetBool("Hansel", !isntCarryingHansel);
        

    }

    void End()
    {
        if (Gretel.escaped || Hansel.escaped)
        {
            Lose = true;
            LoseScreen.SetActive(true);
        }
        if (Gretel.caught && Hansel.caught)
        {
            Win = true;
            WinScreen.SetActive(true);
        }

        if (Lose || Win)
        {
            rend.enabled = false;
            coll.enabled = false;
            anim.enabled = false;
            rb.isKinematic = true;
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

        if (collision.gameObject.CompareTag("Tele"))
        {
            canUseTeleporter = true;
            camnum = collision.gameObject.GetComponent<TeleCam>().thisNum;
            curretnCamNum = collision.gameObject.GetComponent<TeleCam>().thisNum;

        }


        if (collision.gameObject.CompareTag("Fire"))
        {
            if (!isntCarrying)
            {


                collision.gameObject.GetComponent<Fire>().canburn = true;
            }

        }


    }



    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Door") || collision.gameObject.CompareTag("Stairs"))
        {
            AUI.SetActive(false);

            canUseDoor = false;
            doorTeleporting = false;
            canMove = true;
        }

        if (collision.gameObject.CompareTag("Tele"))
        {
            canUseTeleporter = false;

        }

        if (collision.gameObject.CompareTag("Fire"))
        {
           collision.gameObject.GetComponent<Fire>().canburn = false;
        }


    }

}
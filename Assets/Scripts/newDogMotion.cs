using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class newDogMotion : MonoBehaviour
{
    public GameObject doge;
    public GameObject panel;

    public static bool hasEnded;

    [SerializeField] private TextMeshProUGUI thought;
    private string thoughtContent = "will i see him soon?";
    
    
    private float moveForce = 4f;

    
    //private float jumpForce = 5f;

    private float movementX;
    //private float movementY;


    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";

    public static bool canWalk;
    public static bool audioDec = false;

    //private string JUMP_ANIMATION = "Jump";

    //private string GROUND_TAG = "Ground";

    //private string BLOCK_TAG = "Block";

    //private bool isGrounded = true;
   


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canWalk = true;
        hasEnded = false;
        panel.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (canWalk)
        {
            dogMoveKeyboard();
            
        }
        animateDog();

        //animateJump();
        //legsup();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slow")
        {
            StartCoroutine(Slowing());
            audioDec = true;
        }

        if (collision.gameObject.tag == "Corpse")
        {
            StartCoroutine(Stopping());
            StartCoroutine(FadeAway());

        }



    }

    IEnumerator Slowing()
    {

        for (float f = moveForce; f >= 2.3; f -= 0.03f)
        {
            moveForce = f;
            yield return new WaitForSeconds(0.08f);
        }

    }

    IEnumerator Stopping()
    {

        for (float f = moveForce; f >= 0; f -= 0.05f)
        {
            
            moveForce = f;
            yield return new WaitForSeconds(0.05f);
        }
        

    }

    IEnumerator FadeAway()
    {
        for (float f = sr.material.color.a; f >= -0.05f; f -= 0.02f)
        {
            Color color = sr.material.color;
            color.a = f;
            sr.material.color = color;
            yield return new WaitForSeconds(0.09f);
        }

        if (sr.material.color.a <= 0)
        {
            hasEnded = true;
            panel.SetActive(true);
            thought.text = string.Empty;
            StartCoroutine(DisplayLine());
        }
    }

    private IEnumerator DisplayLine()
    {
        yield return new WaitForSeconds(1f);
        //one char at a time
        foreach (char c in thoughtContent.ToCharArray())
        {
            thought.text += c;
            yield return new WaitForSeconds(0.075f);
        }
    }


    void dogMoveKeyboard()
    {
        
            movementX = Input.GetAxis("Horizontal");
            //movementY = Input.GetAxis("Vertical");


            transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
            //transform.position += new Vector3(0f, movementY, 0f) * Time.deltaTime * jumpForce;
        
    }

    void animateDog()
    {
        if (canWalk == false)
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        else
        {

            if (movementX > 0f)
            {
                anim.SetBool(WALK_ANIMATION, true);
                sr.flipX = false;

            }
            else if (movementX < 0f)
            {
                anim.SetBool(WALK_ANIMATION, true);
                sr.flipX = true;

            }
            else
            {
                anim.SetBool(WALK_ANIMATION, false);
                //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0 , 0) ;
            }
        }

    }

    //jump is not used
    /*
    void animateJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;

        }

    }

    void legsup()
    {
        if (isGrounded == false)
        {
            anim.SetBool(JUMP_ANIMATION, true);
            anim.SetBool(WALK_ANIMATION, false);
        }
        else if (isGrounded == true)
        {
            anim.SetBool(JUMP_ANIMATION, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
        /*if (collision.gameObject.CompareTag(BLOCK_TAG))
        {
            isGrounded = true;
            doge.transform.parent = collision.gameObject.transform; 
        }

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PLATFORM_TAG))
        {
            doge.transform.parent = null;
        }
    }

    */




}

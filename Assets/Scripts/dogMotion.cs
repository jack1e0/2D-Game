using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogMotion : MonoBehaviour
{
    public Transform pos4, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;

    [SerializeField]
    private float jumpForce = 5f;
    private bool isGrounded;

    private Rigidbody2D myBody;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";

    private string JUMP_ANIMATION = "Jump";

    private string IDLE_ANIMATION = "Idle";

    private string GROUND_TAG = "Ground";

    private string BLOCK_TAG = "Block";


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.position == pos4.position)
        {
            nextPos = pos3.position;

        }*/


        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

        if (transform.position == pos2.position)
        {
            anim.SetBool(IDLE_ANIMATION, true);
            anim.SetBool(WALK_ANIMATION, false);

        }

        animateJump();
        legsup();
        
        
        
    }
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
            anim.SetBool(WALK_ANIMATION, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(BLOCK_TAG))
        {
            isGrounded = true;
        }

    }
}

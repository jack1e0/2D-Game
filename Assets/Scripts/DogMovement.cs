using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DogMovement : MonoBehaviour
{
    // Making a singleton class
    public static DogMovement instance;
    public bool hasEnded;

    private float moveForce = 4f;
    private float movementX;
    //private float movementY;


    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    public bool canWalk;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        canWalk = true;
        hasEnded = false;
    }

    void Update()
    {
        if (canWalk)
        {
            MoveDog();
        }
        AnimateDog();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slow")
        {
            StartCoroutine(Slowing());
            StartCoroutine(Audio.instance.DecreaseAudio());
        }

        if (collision.gameObject.tag == "Corpse")
        {
            StartCoroutine(Stopping());
            StartCoroutine(FadeAway());
        }
    }

    // Slows at a constant rate
    IEnumerator Slowing()
    {
        for (float f = moveForce; f >= 2.3; f -= 0.03f)
        {
            moveForce = f;
            yield return new WaitForSeconds(0.08f);
        }
    }

    // After slowing for a period of time, finally coming to a stop
    IEnumerator Stopping()
    {
        for (float f = moveForce; f >= 0; f -= 0.05f)
        {
            moveForce = f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    // Dog sprite fading away
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
            StartCoroutine(DialogueManager.instance.FinalLine());
            EntryExitManagement.instance.StartFade();
            StartCoroutine(CloseButton.instance.EndGame());
        }
    }


    void MoveDog()
    {
        movementX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimateDog()
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
            }
        }
    }
}

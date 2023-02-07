using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        if (newDogMotion.hasEnded == true)
        {
            StartCoroutine(endThisShitPls());
        }
    }

    IEnumerator endThisShitPls()
    {
        yield return new WaitForSeconds(6);
        animator.SetTrigger("Quit");
        
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
/// Making close button white to black, for visibility
///
public class CloseButton : MonoBehaviour
{
    public static CloseButton instance;
    public Animator animator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(6);
        animator.SetTrigger("Quit");
    }
}

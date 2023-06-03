using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryExitManagement : MonoBehaviour
{
    public static EntryExitManagement instance;
    public Animator animator;
    public GameObject instructions;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        instructions.SetActive(false);
    }

    // Referenced as a event after animation Lighten finishes
    private IEnumerator ShowInstructions()
    {
        instructions.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        instructions.gameObject.SetActive(false);
    }

    // Fading background to white
    public void StartFade()
    {
        animator.SetBool("Ended", true);
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}

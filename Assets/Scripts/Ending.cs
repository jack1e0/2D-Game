using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    //private newDogMotion newdogmotion;
    public GameObject doge;
    //[SerializeField] private bool isEnded;
    public Animator animator;
    //public GameObject exitButton;
    public GameObject instructions;

    private string isEnded = "Ended";


    // Start is called before the first frame update
    void Start()
    {
        //exitButton.SetActive(false);
        instructions.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (newDogMotion.hasEnded == true)
        {
            StartFade();
            
            
        }
    }

    public void StartFade()
    {
        animator.SetBool(isEnded, true);
    }



    private IEnumerator ShowInstructions()
    {
        instructions.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        instructions.gameObject.SetActive(false);
    }
}

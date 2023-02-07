using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoliceDialogue : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI body;
    [SerializeField] private TextMeshProUGUI speaker;

    //private string[] characters = { "Police", "Police", "Police", "Police", "Police", "Police", "Police" };

    private string[] lines = {"Sigh... what a nasty case.", "The old drunk's done for." , "Killing a person..." , "...barely a few days after a previous crime..." ,
                                    "What was it again?", "...", "Ugh, why is it so chilly? Gives me the jitters." };
    

    public float typeSpeed = 0.02f;
    private int index;

    public GameObject panel;
    

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FastForward();
       
    }

    private void OnTriggerEnter2D(Collider2D character)
    {
        body.text = string.Empty;
        speaker.text = "Police";

        if (character.gameObject.tag == "Dog")
        {
            newDogMotion.canWalk = false;
            panel.SetActive(true);
            StartDialogue();

        }

    }

    private void OnTriggerExit2D(Collider2D character)
    {
        if (character.gameObject.tag == "Dog")
        {
            index = 0;
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(DisplayLine());

    }

    private IEnumerator DisplayLine()
    {

        //one char at a time
        foreach (char c in lines[index].ToCharArray())
        {
            body.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            body.text = "";
            StartCoroutine(DisplayLine());
        }
        else
        {
            panel.SetActive(false);
            newDogMotion.canWalk = true;
        }
    }

    void FastForward()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (body.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                body.text = lines[index];
            }
        }
    }
}
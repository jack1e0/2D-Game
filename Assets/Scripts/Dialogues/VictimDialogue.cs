using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictimDialogue : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI body;
    [SerializeField] private TextMeshProUGUI speaker;

    private string[] characters = { "Dog", "...Ghost?", "...Ghost?", "Dog", "...Ghost", "...Ghost", "...Ghost", "Dog", "Ghost", "Ghost", "Dog" };
    
    private string[] lines = {"Woof!", "Oh hey doggy...", "I will talk to you, since no one else can see me.", "* Wags tail *",
                                   "I have got to vent my anger...",  
                                   "A few days ago I was beat up by some drunkard!", "The next thing I know, I am stuck here...",
                                   "..." , "It would be nice to have some company...", "..." , "..." };


    public float typeSpeed = 0.02f;
    public int index;

    public GameObject panel;
    public GameObject doge;
    //private bool stop = false;

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
        speaker.text = characters[0];

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
            speaker.text = characters[index];
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
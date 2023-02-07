using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManDialogue : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI body;
    [SerializeField] private TextMeshProUGUI speaker;

    private string[] line = {"Hello doggy, out alone are we?", "...", "Well, where is that owner of yours? Everytime I see you, you get skinnier!", 
                              "...", "Well, run along now."};
    private string[] characters = { "Man", "Dog", "Man", "Dog", "Man"};


    
    public float typeSpeed = 0.03f;
    private int index;

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
        foreach (char c in line[index].ToCharArray())
        {
            body.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    void NextLine()
    {
        if (index < line.Length - 1)
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
            if (body.text == line[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                body.text = line[index];
            }
        }
    }
}

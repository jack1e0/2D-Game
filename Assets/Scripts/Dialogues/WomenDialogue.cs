using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WomenDialogue : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI body;
    [SerializeField] private TextMeshProUGUI speaker;

    private string[] characters = {"Lady 1", "Lady 2", "Lady 2", "Lady 1", "Lady 1", "Lady 2", "Lady 1"};
    private string[] lines = {"Have you heard the rumour lately?", 
                              "Yes, I heard that the old man down the street got arrested!", "Apparently he beat somebody up.", 
                              "A leopard never changes its spots...",  "He got into trouble a few times for violence in the past.", 
                              "And I used to hear terrible barking from his house!", "Wonder how his poor dog is holding up..."};
    


    public float typeSpeed = 0.02f;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public GameObject panel;
    [SerializeField] private TextMeshProUGUI body;
    [SerializeField] private TextMeshProUGUI heading;
    private bool isTextShowing;

    private int index;
    private string[] content;
    private string[] speakerName;
    private float typeSpeed = 0.02f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        index = 0;
        panel.SetActive(false);
    }

    void Update()
    {
        if (isTextShowing)
        {
            FastForward();
        }
    }

    private void OnTriggerEnter2D(Collider2D character)
    {
        if (character.gameObject.tag == "Man")
        {
            content = Man.lines;
            speakerName = Man.characters;
            StartDialogue();
        }

        if (character.gameObject.tag == "Women")
        {
            content = Women.lines;
            speakerName = Women.characters;
            StartDialogue();
        }

        if (character.gameObject.tag == "Police")
        {
            content = Police.lines;
            speakerName = Police.characters;
            StartDialogue();
        }

        if (character.gameObject.tag == "Victim")
        {
            content = Victim.lines;
            speakerName = Victim.characters;
            StartDialogue();
        }

        if (character.gameObject.tag == "Blood")
        {
            content = Blood.lines;
            speakerName = Blood.characters;
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        body.text = string.Empty;
        if (speakerName.Length == 0)
        {
            heading.text = string.Empty;
        }
        else
        {
            heading.text = speakerName[0];
        }

        DogMovement.instance.canWalk = false;
        panel.SetActive(true);
        isTextShowing = true;
        index = 0;
        StartCoroutine(DisplayLine());
    }

    private IEnumerator DisplayLine()
    {
        //one char at a time
        foreach (char c in content[index].ToCharArray())
        {
            body.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    void NextLine()
    {
        if (index < content.Length - 1)
        {
            index++;
            body.text = "";
            if (speakerName.Length != 0)
            {
                heading.text = speakerName[index];
            }
            StartCoroutine(DisplayLine());
        }
        else
        {
            isTextShowing = false;
            panel.SetActive(false);
            DogMovement.instance.canWalk = true;
            index = 0;
        }
    }

    void FastForward()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (body.text == content[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                body.text = content[index];
            }
        }
    }

    // Used only when dog approaches corpse at the end of game
    public IEnumerator FinalLine()
    {
        panel.SetActive(true);
        heading.text = string.Empty;
        body.text = string.Empty;
        yield return new WaitForSeconds(1f);
        foreach (char c in FinalThoughts.lines[0].ToCharArray())
        {
            body.text += c;
            yield return new WaitForSeconds(0.075f);
        }
    }
}

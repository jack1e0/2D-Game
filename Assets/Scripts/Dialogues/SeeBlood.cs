using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeeBlood : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI thoughts;
    [SerializeField] private GameObject panel;

    private string[] thoughtsContent = {"* Sniffs *", "( Red... splatters...? )"};
    private int index;
    public float typeSpeed = 0.02f;

    //private newDogMotion newdogmotion;
    public GameObject doge;

    private bool spottedBlood;

    private void Awake()
    {
        //newdogmotion = doge.GetComponent<newDogMotion>();
    }

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        panel.SetActive(false);
        spottedBlood = false; 
    }

    // Update is called once per frame
    void Update()
    {
        FastForward();
    }

    
    private void OnTriggerEnter2D(Collider2D doge)
    {

        if (spottedBlood == false)
        {
            if (doge.gameObject.tag == "Dog")
            {
                panel.SetActive(true);
                //thoughts1.text = string.Empty;
                thoughts.text = string.Empty;
                newDogMotion.canWalk = false;
                StartThinking();

            }
        }
    }

    private void OnTriggerExit2D(Collider2D doge)
    {
        if (doge.gameObject.tag == "Dog")
        {
            index = 0;
        }
    }

    void StartThinking()
    {
        index = 0;

        StartCoroutine(DisplayThoughts());
        
        //StopCoroutine(DisplayThoughts1());


    }
    
    private IEnumerator DisplayThoughts()
    {
       
        foreach (char ch in thoughtsContent[index].ToCharArray())
        {
            thoughts.text += ch;
            yield return new WaitForSeconds(typeSpeed);
        }
    }


    void NextLine()
    {
        if (index < thoughtsContent.Length - 1)
        {
            index++;
            thoughts.text = "";
            
            StartCoroutine(DisplayThoughts());
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
            if (thoughts.text == thoughtsContent[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                thoughts.text = thoughtsContent[index];
            }
        }
    }



}

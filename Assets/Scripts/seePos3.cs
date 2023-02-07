using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class seePos3 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI thoughts;
    [SerializeField] private GameObject panel;

    private string[] thoughtsContent = { "* Sniffs *", "( Red... splatters...? )" };
    private int index2;
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
        index2 = 0;
        panel.SetActive(false);
        spottedBlood = false;
    }

    // Update is called once per frame
    void Update()
    {
        NextLine();
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
            index2 = 0;
        }
    }

    void StartThinking()
    {
        index2 = 0;

        StartCoroutine(DisplayThoughts1());

        //StopCoroutine(DisplayThoughts1());


    }

    private IEnumerator DisplayThoughts1()
    {


        yield return new WaitForSeconds(0.5f);

        thoughts.text = string.Empty;
        StartCoroutine(DisplayThoughts2());
    }

    private IEnumerator DisplayThoughts2()
    {

        foreach (char ch in thoughtsContent[index2].ToCharArray())
        {
            thoughts.text += ch;
            yield return new WaitForSeconds(typeSpeed);
        }


    }

    void NextLine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (index2 < thoughtsContent.Length - 1)
            {
                index2++;
                thoughts.text = string.Empty;
                StartCoroutine(DisplayThoughts2());
            }
            else
            {

                StopAllCoroutines();
                panel.SetActive(false);
                newDogMotion.canWalk = true;
                spottedBlood = true;

            }
        }
    }



}
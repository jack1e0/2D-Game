using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bodyWriter : MonoBehaviour
{

    public TextMeshProUGUI body;
    public TextMeshProUGUI speaker;


    private float timePerChar = 0.05f;


    /*
    [SerializeField] private bodyAssistant bodyassistant;
    public TextMeshProUGUI bodyText;

    private string bodyContent = "Hey doggy, out by yourself?";

    private void Awake()
    {
        bodyText = transform.Find("Body").GetComponent<TextMeshProUGUI>();
    }


    // Start is called before the first frame update
    void Start()
    {
        bodyassistant.AddBody(bodyText, bodyContent, 0.2f);
    }



    // Update is called once per frame
    void Update()
    {

    }
    */

    private void Start()
    {
        StartCoroutine(displayLine());
    }

    private IEnumerator displayLine()
    {
        //initially is empty
        body.text = "";
        speaker.text = "Man";

        //then one char at a time
        foreach (char c in body.text.ToCharArray())
        {
            body.text += c;
            yield return new WaitForSeconds(timePerChar);
        }
    }
    
}


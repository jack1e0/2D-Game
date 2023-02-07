using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bodyAssistant : MonoBehaviour
{
    
    private TextMeshProUGUI body;
    private string content;
    private float timePerChar;

    private int charIndex;
    private float timer;
    
    public void AddBody(TextMeshProUGUI body, string content, float timePerChar)
    {
        body = GetComponent<TextMeshProUGUI>(); 
        this.content = content;
        this.timePerChar = timePerChar;

        charIndex = 0;
    }
    

    // Update is called once per frame
    void Update()
    {
        //typing animation

        while (body != null)
        {
            timer -= Time.deltaTime;

            //display next character
            timer += timePerChar;
            charIndex++;
            body.text = content.Substring(0, charIndex);
            
        }

        body.text = content;
        if (charIndex > content.Length)
        {
            //entire text displayed
            body = null;
            return;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{

    public GameObject newCloud;
    public GameObject oldCloud;


    SpriteRenderer newRend;
    SpriteRenderer oldRend;

    Color newColour;
    Color oldColour;    


    // Start is called before the first frame update
    void Start()
    {
        newRend = newCloud.GetComponent<SpriteRenderer>();
        newColour = newRend.material.color;
        

        oldRend = oldCloud.GetComponent<SpriteRenderer>();
        oldColour = oldRend.material.color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D doge)
    {
        if (doge.gameObject.tag == "Dog")
        {
            startChange();
        }
    }

    IEnumerator FadeRed()
    {
        for (float i = oldColour.r; i <= newColour.r; i += 0.05f)
        {
            
            
            oldColour.r = i;
            oldRend.material.color = oldColour;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeGreen()
    {
        for (float i = oldColour.g; i <= newColour.g; i += 0.05f)
        {
            oldColour.g = i;
            oldRend.material.color = oldColour;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeBlue()
    {
        for (float i = oldColour.b; i <= newColour.b; i += 0.05f)
        {
           
            oldColour.b = i;
            oldRend.material.color = oldColour;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void startChange()
    {
        StartCoroutine(FadeBlue());
        StartCoroutine(FadeGreen());
        StartCoroutine(FadeRed());
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public GameObject thing;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = thing.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D doge)
    {
        if (doge.gameObject.tag == "Dog")
        {
            startFadeOut();
        }
    }

    IEnumerator FadingOut()
    {
        
        for (float f = 1; f >= -0.05f; f -= 0.03f)
        {
            Color color = spriteRenderer.material.color;
            color.a = f;
            spriteRenderer.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }      

    }

    public void startFadeOut()
    {
        StartCoroutine(FadingOut());
    }
}

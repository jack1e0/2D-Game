using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public GameObject thing;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = thing.GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.material.color;
        color.a = 0f;
        spriteRenderer.material.color = color;
    }

    private void OnTriggerEnter2D(Collider2D doge)
    {
        if (doge.gameObject.tag == "Dog")
        {
            StartFadeIn();
        }
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadingIn());
    }

    IEnumerator FadingIn()
    {
        for (float f = 0.05f; f < 1; f += 0.03f)
        {
            Color c = spriteRenderer.material.color;
            c.a = f;
            spriteRenderer.material.color = c;
            yield return new WaitForSeconds(0.07f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
/// Making dog become transparent
///
public class Ghostify : MonoBehaviour
{
    public GameObject doggo;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = doggo.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D doge)
    {
        if (doge.gameObject.tag == "Dog")
        {
            StartGhostify();
        }
    }

    public void StartGhostify()
    {
        StartCoroutine(Ghostifying());
    }

    IEnumerator Ghostifying()
    {
        for (float f = 1; f >= 0.4f; f -= 0.01f)
        {
            Color color = spriteRenderer.material.color;
            color.a = f;
            spriteRenderer.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
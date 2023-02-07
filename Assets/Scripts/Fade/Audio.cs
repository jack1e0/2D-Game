using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public AudioSource bgm;
    private float timeTaken = 2f;
    private float timeElapsed = 0f;

    // Update is called once per frame
    void Update()
    {
        if (newDogMotion.audioDec == true)
        {
            
                bgm.volume = Mathf.Lerp(1, 0, timeElapsed / timeTaken);
                timeElapsed += Time.deltaTime;
            
        }
    }
}

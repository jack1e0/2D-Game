using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public static Audio instance;
    public AudioSource bgm;
    private float timeTaken = 4f;
    private float timeElapsed = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public IEnumerator DecreaseAudio()
    {
        while (bgm.volume > 0)
        {
            bgm.volume = Mathf.Lerp(1, 0, timeElapsed / timeTaken);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}

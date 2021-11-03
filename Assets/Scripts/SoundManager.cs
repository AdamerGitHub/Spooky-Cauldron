using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public MagicCauldron magicCauldron;
    public AudioSource lightningSound;
    public AudioSource witchLaughting1;
    public AudioSource witchLaughting2;
    public AudioSource witchLaughting3;

    public float timeToStartSound = 3f;

    bool witchLaugh1 = false;
    bool witchLaugh2 = false;
    bool witchLaugh3 = false;

    float time;
    float time1;
    bool lightningSoundStarted = false;
    bool end = false;

    void Update()
    {
        if (!end)
        {
            time += Time.deltaTime;
        }
        if (time >= timeToStartSound && !lightningSoundStarted)
        {
            lightningSound.Play();
            magicCauldron.lightningSoundStarted = true;
            lightningSoundStarted = true;
        }
        if (time >= 2f && !witchLaugh1)
        {
            witchLaughting1.Play();
            witchLaugh1 = true;
        }
        if (time >= 35.5f && !witchLaugh2)
        {
            witchLaughting2.Play();
            witchLaugh2 = true;
        }
        if (time >= 66f && !witchLaugh3)
        {
            witchLaughting3.Play();
            witchLaugh3 = true;
            time = 0f;
            end = true;
        }
        /*
        if(time >= 36.5f && !witchLaugh1)
        {
            witchLaughting1.Play();
            witchLaugh1 = true;
        }
        if(time >= 71f && !witchLaugh2)
        {
            witchLaughting2.Play();
            witchLaugh2 = true;
            time = 0f;
            end = true;
        }
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirefliesMusic : MonoBehaviour
{
    public ParticleSystem myPS;
    public AudioSource sparklingsMusic;
    public AudioClip sparklingsClip;
    
    float time = 0f;
    bool isPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayed)
        {
            time += Time.deltaTime;
        }

        if(time >= myPS.main.startDelay.constant && !isPlayed)
        {
            sparklingsMusic.Play();
            isPlayed = true;
        }
    }
}

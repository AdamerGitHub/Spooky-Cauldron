using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicCauldron : MonoBehaviour
{
    public GameObject firefliesGO;
    public GameObject firefliesLight;
    public GameObject[] lightningGO;
    public GameObject[] lightForLightningGO;
    public Transform lightForLightningSpawner;
    public Transform firefliesSpawner;
    public Transform lightningSpawner;

    public SoundManager soundManager;

    public float timeToRestart;

    float time = 0f;
    bool oneLightningUsed = false;
    bool twoLightningUsed = false;
    bool threeLightningUsed = false;
    bool lastUsedLightning = false;
    bool fireFliesLightOn = false;
    bool waitRestart = false;

    public bool lightningSoundStarted = false;

    void Start()
    {
        GameObject createdFireflies = Instantiate(firefliesGO, firefliesSpawner.position, firefliesSpawner.rotation, firefliesSpawner);
        createdFireflies.GetComponent<ParticleSystem>().startDelay = 8f + soundManager.timeToStartSound;

        Destroy(createdFireflies, createdFireflies.GetComponent<ParticleSystem>().main.startDelay.constant + createdFireflies.GetComponent<ParticleSystem>().main.startLifetime.constant + 10f);
    }

    void Update()
    {
        // Do not CHANGE PLS, (Using in SOUND MANAGER SCRIPT)
        if (lightningSoundStarted)
        {
            CreateLightning();
        }
    }

    // Start in Sound Manager Script (Script attached on Sound Manager in "Hierarchy")
    void CreateLightning()
    {
        if (!lastUsedLightning)
        {
            time += Time.deltaTime;
        }
        if(time >= 1f && !oneLightningUsed)
        {
            // RESET LIGHTNINGS, AND FIREFLIES, WHEN COUNTS SOME TIMES
            StartCoroutine(RestartLightning());

            GameObject lightning = Instantiate(lightningGO[0], lightningSpawner.position, lightningSpawner.rotation, lightningSpawner);
            Destroy(lightning, .05f);
            oneLightningUsed = true;

            GameObject lightForLightning = Instantiate(lightForLightningGO[0], lightForLightningSpawner.position, lightForLightningSpawner.rotation, lightForLightningSpawner);

            Destroy(lightForLightning, 1f);
        }
        else if (time >= 1.5f && !twoLightningUsed)
        {
            GameObject lightning = Instantiate(lightningGO[1], lightningSpawner.position, lightningSpawner.rotation, lightningSpawner);
            Destroy(lightning, .15f);
            twoLightningUsed = true;

            GameObject lightForLightning = Instantiate(lightForLightningGO[1], lightForLightningSpawner.position, lightForLightningSpawner.rotation, lightForLightningSpawner);

            Destroy(lightForLightning, 1f);
        }
        else if (time >= 6.09 && !threeLightningUsed)
        {
            GameObject lightning = Instantiate(lightningGO[2], lightningSpawner.position, lightningSpawner.rotation, lightningSpawner);
            Destroy(lightning, .1f);
            threeLightningUsed = true;

            GameObject lightForLightning = Instantiate(lightForLightningGO[2], lightForLightningSpawner.position, lightForLightningSpawner.rotation, lightForLightningSpawner);

            Destroy(lightForLightning, 1f);
        }
        else if(time >= 7.35 && !lastUsedLightning)
        {
            GameObject lightning = Instantiate(lightningGO[3], lightningSpawner.position, lightningSpawner.rotation, lightningSpawner);
            StartCoroutine (lastEpicLighting(lightning.GetComponent<Light>()));
            Destroy(lightning, .35f);
            lastUsedLightning = true;

            GameObject lightForLightning = Instantiate(lightForLightningGO[3], lightForLightningSpawner.position, lightForLightningSpawner.rotation, lightForLightningSpawner);

            Destroy(lightForLightning, 1f);
        }
        // CREATING LIGHT FOR FIREFLIES
        else if(time >= 7.35f && lastUsedLightning && !fireFliesLightOn)
        {
            GameObject fireFliesLight = Instantiate(firefliesLight, lightForLightningSpawner.position, lightForLightningSpawner.rotation, lightForLightningSpawner);
            Destroy(fireFliesLight, 10f);

            fireFliesLightOn = true;
        }
    }

    IEnumerator RestartLightning()
    {
        float time1 = 0f;
        ParticleSystem firefliesPS = firefliesGO.GetComponent<ParticleSystem>();

        while (true)
        {
            time1 += Time.deltaTime;
            if (time1 >= firefliesPS.main.startLifetime.constant + firefliesPS.main.startDelay.constant + timeToRestart)
            {
                GameObject createdFirefliesGO = Instantiate(firefliesGO, firefliesSpawner.position, firefliesSpawner.rotation, firefliesSpawner);
                ParticleSystem createdFirefliesPS = createdFirefliesGO.GetComponent<ParticleSystem>();
                createdFirefliesPS.startDelay = 8f;
                createdFirefliesPS.maxParticles = 75;
                createdFirefliesPS.emissionRate = 15;

                Destroy(createdFirefliesGO, createdFirefliesGO.GetComponent<ParticleSystem>().main.startDelay.constant + createdFirefliesGO.GetComponent<ParticleSystem>().main.startLifetime.constant + 10f);

                time = 0f;
                oneLightningUsed = false;
                twoLightningUsed = false;
                threeLightningUsed = false;
                lastUsedLightning = false;
                fireFliesLightOn = false;
                waitRestart = false;
                soundManager.lightningSound.Play();

                lightningSoundStarted = true;
                break;
            }

            yield return null;
        }
    }

    IEnumerator lastEpicLighting(Light lightning)
    {
        lightning.intensity = 5;

        while (true)
        {
            if(lightning == null)
            {
                break;
            }

            lightning.intensity -= Time.deltaTime / 2;
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public AudioSource winAudioSource;
    public AudioClip winAudioClip;
    public ParticleSystem[] winParticles;
    public float requiredTimeInside = 2.0f;
    private float currentTimeInside = 0.0f;
    private bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInside = false;
            currentTimeInside = 0.0f;
        }
    }

    private void Update()
    {
        if (isInside)
        {
            currentTimeInside += Time.deltaTime;

            if (currentTimeInside >= requiredTimeInside)
            {
                // The entire collider has been inside for the required time
                Debug.Log("Collider is completely inside for the required time!");
                winAudioSource.PlayOneShot(winAudioClip);
                for (int i = 0; i < winParticles.Length; i++)
                {
                    winParticles[i].Play();
                }
            }
        }
    }
}